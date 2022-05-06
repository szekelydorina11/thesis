namespace thesisUI.Filters
{
    class InverseTransform : Transform
    {
        public override int TransformData(int pixel)
        {
            byte r = (byte)(pixel & 0x0000FF);
            byte g = (byte)((pixel & 0x00FF00) >> 8);
            byte b = (byte)((pixel & 0xFF0000) >> 16);

            r = (byte)(255 - r);
            g = (byte)(255 - g);
            b = (byte)(255 - b);
            return (b << 16) | (g << 8) | r;
        }
    }
}
