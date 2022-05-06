using System;

namespace thesisUI.Filters
{
    class SetBrightnessTransform : Transform
    {
        public SetBrightnessTransform(int brightness)
        {
            m_increment = brightness - 128;
        }

        public override int TransformData(int pixel)
        {
            byte r = (byte)(pixel & 0x0000FF);
            byte g = (byte)((pixel & 0x00FF00) >> 8);
            byte b = (byte)((pixel & 0xFF0000) >> 16);

            r = (byte)Math.Max(0, Math.Min(255, r + m_increment));
            g = (byte)Math.Max(0, Math.Min(255, g + m_increment));
            b = (byte)Math.Max(0, Math.Min(255, b + m_increment));
            return (b << 16) | (g << 8) | r;
        }

        private readonly int m_increment;
    }
}
