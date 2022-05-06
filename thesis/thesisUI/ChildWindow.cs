using thesisUI.Filters;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace thesisUI
{
    public partial class ChildWindow : Form
    {
        public ChildWindow(string fileName)
        {
            InitializeComponent();
            Text = Path.GetFileName(fileName);
            m_fileName = fileName;

            m_originalImage = new Bitmap(m_fileName);
            LoadImage(m_originalImage);
        }

        internal void Save()
        {
            pbOriginalImage.Image.Save(m_fileName);
        }

        internal void SaveAs()
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = $"Current image|*{Path.GetExtension(m_fileName)}"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                pbOriginalImage.Image.Save(sfd.FileName);
                m_fileName = sfd.FileName;
                Text = Path.GetFileName(m_fileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ImageTransformer transformer = new ImageTransformer((Bitmap)pbOriginalImage.Image);
            m_originalImage = transformer.Transform(new InverseTransform());
            LoadImage(m_originalImage);
        }

        private void btnCollimate_Click(object sender, EventArgs e)
        {
            var result = 
                NativeMethods.imageProcess(m_fileName);

        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            m_originalImage = new Bitmap(m_fileName);
            LoadImage(m_originalImage);
            trackBar1.Value = 128;
        }

        private void LoadImage(Bitmap image)
        {
            ThreadSafe(c => c.Image = image, pbOriginalImage);
            var imageClip = new Rectangle(new Point(0, 0), image.Size);
            var copy = image.Clone(imageClip, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            GenerateHistogram(copy);
            GenerateChannels(copy);
        }

        private void GenerateHistogram(Bitmap copy)
        {
            var imageClip = new Rectangle(new Point(0, 0), copy.Size);
            long[] r = new long[256];
            long[] g = new long[256];
            long[] b = new long[256];
            unsafe
            {
                var bitmapData = copy.LockBits(imageClip, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                int offset = bitmapData.Stride - bitmapData.Width * 4;
                var scan = bitmapData.Scan0;
                for (int y = 0; y < bitmapData.Height; y++)
                {
                    for (int x = 0; x < bitmapData.Width; x++)
                    {
                        int pixel = *((int*)scan);
                        r[pixel & 0x0000FF]++;
                        g[(pixel & 0x00FF00) >> 8]++;
                        b[(pixel & 0xFF0000) >> 16]++;
                        scan += 4;
                    }
                    scan += offset;
                }
                copy.UnlockBits(bitmapData);
            }

            double max = 0;
            for (int i = 0; i < 256; i++)
            {
                if (max < r[i]) { max = r[i]; }
                if (max < g[i]) { max = g[i]; }
                if (max < b[i]) { max = b[i]; }
            }

            Bitmap histogram = new Bitmap(256, 64);
            unsafe
            {
                var bitmapData = histogram.LockBits(new Rectangle(0, 0, histogram.Width, histogram.Height),
                    System.Drawing.Imaging.ImageLockMode.WriteOnly,
                    System.Drawing.Imaging.PixelFormat.Format32bppRgb);

                var scan = bitmapData.Scan0;
                int offset = bitmapData.Stride - bitmapData.Width * 4;

                for (int y = 0; y < bitmapData.Height; y++)
                {
                    double currentThresold = y / (double)bitmapData.Height;

                    for (int x = 0; x < bitmapData.Width; x++)
                    {
                        int deltaR = 255;
                        int deltaG = 255;
                        int deltaB = 255;

                        double tresholdR = 1 - (r[x] / max);
                        double tresholdG = 1 - (g[x] / max);
                        double tresholdB = 1 - (b[x] / max);

                        if (currentThresold < tresholdR)
                        {
                            deltaR = 0;
                        }
                        if (currentThresold < tresholdG)
                        {
                            deltaG = 0;
                        }
                        if (currentThresold < tresholdB)
                        {
                            deltaB = 0;
                        }

                        *((int*)scan) = (deltaB << 16) | (deltaG << 8) | deltaR;
                        scan += 4;
                    }
                    scan += offset;
                }
                histogram.UnlockBits(bitmapData);
            }
            var action = new Action<Image>(i => pbHistogram.Image = i);
            if (pbHistogram.InvokeRequired)
            {
                pbHistogram.Invoke(action, histogram);
            }
            else
            {
                action(histogram);
            }
        }

        private void GenerateChannels(Bitmap copy)
        {
            var red = GenerateChannel(copy, Channel.Red);
            var green = GenerateChannel(copy, Channel.Green);
            var blue = GenerateChannel(copy, Channel.Blue);

            ThreadSafe(c => c.Image = red, pbRed);
            ThreadSafe(c => c.Image = green, pbGreen);
            ThreadSafe(c => c.Image = blue, pbBlue);
            ThreadSafe(control => control.Image = copy, pbCombined);
        }

        private Bitmap GenerateChannel(Bitmap bitmap, Channel channel)
        {
            ImageTransformer transformer = new ImageTransformer(bitmap);
            return transformer.Transform(new ExtractChannelTransform(channel));
        }

        private void ThreadSafe<T>(Action<T> method, T control)
            where T: Control
        {
            if (control.InvokeRequired)
            {
                control.Invoke(method, control);
            }
            else
            {
                method(control);
            }
        }

        private void pbRed_Click(object sender, EventArgs e)
        {
            pbOriginalImage.Image = ((PictureBox)sender).Image;
        }

        private string m_fileName;
        private Bitmap m_originalImage;

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            int value = trackBar1.Value;
            ImageTransformer transformer = new ImageTransformer(m_originalImage);
            var bmp = transformer.Transform(new SetBrightnessTransform(value));
            LoadImage(bmp);

        }
    }
}
