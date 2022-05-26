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
            main.Image.Save(m_fileName);
        }

        internal void SaveAs()
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = $"Current image|*{Path.GetExtension(m_fileName)}"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                main.Image.Save(sfd.FileName);
                m_fileName = sfd.FileName;
                Text = Path.GetFileName(m_fileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ImageTransformer transformer = new ImageTransformer((Bitmap)main.Image);
            m_originalImage = transformer.Transform(new InverseTransform());
            LoadImage(m_originalImage);
        }

        private void btnCollimate_Click(object sender, EventArgs e)
        {
            Console.Write("file_name: " + m_fileName);

            var result = Path.GetFileNameWithoutExtension(m_fileName);
            Console.Write("result: " + result);

            NativeMethods.imageProcess(m_fileName);
            //if (result == "") return;

            String new_file_name = result + "_imgThre.jpg";
            Console.WriteLine("new_file_name: " + new_file_name);

            m_imgThre = new Bitmap(new_file_name);
            LoadImage(m_imgThre);

            new_file_name = result + "_imgThre.jpg";
            //m_imgThre = new Bitmap(new_file_name);
            pictureBox1.Image = m_imgThre;
            pictureBox1.Visible = true;

            new_file_name = result + "_GaussianBlur.jpg";
            m_imgBlur = new Bitmap(new_file_name);
            pictureBox2.Image = m_imgBlur;
            pictureBox2.Visible = true;

            new_file_name = result + "_Canny.jpg";
            m_imgCanny = new Bitmap(new_file_name);
            pictureBox3.Image = m_imgCanny;
            pictureBox3.Visible = true;

            new_file_name = result + "_Dilate.jpg";
            m_imgDilate = new Bitmap(new_file_name);
            pictureBox4.Image = m_imgDilate;
            pictureBox4.Visible = true;

            /*new_file_name = result + "_Erode.jpg";
            m_imgCanny = new Bitmap(new_file_name);
            pictureBox2.Image = m_imgErode;*/
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            m_originalImage = new Bitmap(m_fileName);
            LoadImage(m_originalImage);
            trackBar1.Value = 128;
        }

        private void LoadImage(Bitmap image)
        {
            ThreadSafe(c => c.Image = image, main);
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
            main.Image = ((PictureBox)sender).Image;
        }

        private string m_fileName;
        private Bitmap m_originalImage;
        private Bitmap m_imgThre;
        private Bitmap m_imgBlur;
        private Bitmap m_imgCanny;
        private Bitmap m_imgDilate;

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            int value = trackBar1.Value;
            ImageTransformer transformer = new ImageTransformer(m_originalImage);
            var bmp = transformer.Transform(new SetBrightnessTransform(value));
            LoadImage(bmp);
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if (main.Image == null)
            {
                MessageBox.Show("Choose picture!");
            }
            else
            {
                var img1 = pictureBox1.Image;
                //pictureBox1.Image = main.Image;
                main.Image = img1;
            }
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            if (main.Image == null)
            {
                MessageBox.Show("Choose picture!");
            }
            else
            {
                var img3 = pictureBox3.Image;
                //pictureBox3.Image = main.Image;
                main.Image = img3;
            }
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            if (main.Image == null)
            {
                MessageBox.Show("Choose picture!");
            }
            else
            {
                var img2 = pictureBox2.Image;
                //pictureBox2.Image = main.Image;
                main.Image = img2;
            }
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            if (main.Image == null)
            {
                MessageBox.Show("Choose picture!");
            }
            else
            {
                var img4 = pictureBox4.Image;
                //pictureBox4.Image = main.Image;
                main.Image = img4;
            }
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }
}
