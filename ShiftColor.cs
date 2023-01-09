using System.Drawing;

namespace ColorHelper
{
    /// <summary>
    /// a shift color is made out of 3 colors and can shift a third color around in color space
    /// </summary>
    public struct ShiftColor
    {
        public ShiftColor()
        {
            Red_channel = RandomColor.Next();
            Blue_channel = RandomColor.Next();
            Green_channel = RandomColor.Next();
        }
        public ShiftColor(Color red, Color green, Color blue)
        {
            Red_channel = red;
            Blue_channel = green;
            Green_channel = blue;
        }
        public Color Red_channel { get; set; }
        public Color Blue_channel { get; set; }
        public Color Green_channel { get; set; }
    }
}
