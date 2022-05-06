namespace thesisUI.Filters
{
    class ExtractChannelTransform : Transform
    {
        public ExtractChannelTransform(Channel channel)
        {
            m_channel = channel;
        }

        public override int TransformData(int pixel)
        {
            byte r = (byte)(pixel & 0x0000FF);
            byte g = (byte)((pixel & 0x00FF00) >> 8);
            byte b = (byte)((pixel & 0xFF0000) >> 16);

            r = (byte)(r * ((m_channel & Channel.Red) == Channel.Red ? 1 : 0));
            g = (byte)(g * ((m_channel & Channel.Green) == Channel.Green ? 1 : 0));
            b = (byte)(b * ((m_channel & Channel.Blue) == Channel.Blue ? 1 : 0));
            return (b << 16) | (g << 8) | r;
        }

        private readonly Channel m_channel;
    }

    enum Channel
    {
        Red = 1,
        Green = 2,
        Blue = 4,
        All = Red | Green | Blue
    }
}
