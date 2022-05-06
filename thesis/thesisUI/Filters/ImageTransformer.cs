using System.Drawing;

namespace thesisUI.Filters
{
    class ImageTransformer
    {
        public ImageTransformer(Bitmap bitmap)
        {
            var imageClip = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            m_bitmap = bitmap.Clone(imageClip, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
        }

        public unsafe Bitmap Transform(Transform transform)
        {
            unsafe
            {
                var imageClip = new Rectangle(0, 0, m_bitmap.Width, m_bitmap.Height);
                var bitmapData = m_bitmap.LockBits(imageClip, System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                int offset = bitmapData.Stride - bitmapData.Width * 4;
                var scan = bitmapData.Scan0;
                for (int y = 0; y < bitmapData.Height; y++)
                {
                    for (int x = 0; x < bitmapData.Width; x++)
                    {
                        int pixel = *((int*)scan);
                        *((int*)scan) = transform.TransformData(pixel);
                        scan += 4;
                    }
                    scan += offset;
                }
                m_bitmap.UnlockBits(bitmapData);
            }
            return m_bitmap;
        }

        readonly Bitmap m_bitmap;
    }
}
