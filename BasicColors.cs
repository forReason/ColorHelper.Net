namespace ColorHelper
{
    public enum RGB_BasicColors
    {
        Red,
        Green,
        Blue
    }
    /// <summary>
    /// a coloramount is a volume of a certain color. It can be used to mix colors together. Kind of like you would mix 500ml green color with 50ml white color
    /// </summary>
    public struct ColorAmount
    {
        public ColorAmount(System.Drawing.Color color, double volume)
        {
            this.Color = color;
            this.Volume = volume;
        }
        public System.Drawing.Color Color;
        public double Volume;
    }
    /// <summary>
    /// a coloramount is a volume of a certain color. It can be used to mix colors together. Kind of like you would mix 500ml green color with 50ml white color
    /// </summary>
    public struct ShiftColorAmount
    {
        public ShiftColorAmount(ShiftColor color, double volume)
        {
            this.Color = color;
            this.Volume = volume;
        }
        public ShiftColor Color;
        public double Volume;
    }
}
