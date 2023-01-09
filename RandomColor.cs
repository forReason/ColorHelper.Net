using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorHelper
{
    /// <summary>
    /// random color class can be used to obtain a random color
    /// </summary>
    public class RandomColor
    {
        private static Random random = new Random();
        /// <summary>
        /// generates a totally random color
        /// </summary>
        /// <param name="includeAlpha"></param>
        /// <returns></returns>
        public static Color Next(bool includeAlpha = false, double primeColorChance = 0.2)
        {
            if (random.NextDouble() <= primeColorChance && primeColorChance > 0)
            {
                int luck = random.Next(1, 4);
                if (luck == 1)
                {
                    return Color.FromArgb(255, 255, 0, 0);
                }
                else if (luck == 2)
                {
                    return Color.FromArgb(255, 0, 255, 0);
                }
                else
                {
                    return Color.FromArgb(255, 0, 0, 255);
                }
            }
            // get random color values
            int r = random.Next(0, 256);
            int g = random.Next(0, 256);
            int b = random.Next(0, 256);
            int a = 255;
            // brighten color to max
            int max = Math.Max(r, g);
            max = Math.Max(max, b);
            // get brighten factor
            double brightenFactor = 255.0 / max;
            r = (int)(r * brightenFactor);
            g = (int)(g * brightenFactor);
            b = (int)(b * brightenFactor);
            if (includeAlpha) a = random.Next(0, 256);
            // create color
            return System.Drawing.Color.FromArgb(a, r, g, b);
        }
        /// <summary>
        /// Gets a random hue and saturation from a selected base color
        /// </summary>
        /// <param name="color"></param>
        /// <param name="saturation"></param>
        /// <param name="brightness"></param>
        /// <returns></returns>
        public static Color Next(RGB_BasicColors color, double saturation, double brightness)
        {
            double angle = 0;
            if (color == RGB_BasicColors.Red)
            {
                angle = random.Next(325, 405);
                if (angle > 360) angle -= 360;
            }
            else if (color == RGB_BasicColors.Green)
            {
                angle = random.Next(65, 145);
            }
            else
            {
                angle = random.Next(170, 275);
            }
            double offset = random.NextDouble();
            offset -= 0.5;
            angle += offset;
            if (angle > 360) angle -= 1;
            Color c = ColorConverter.ColorFromHSV(angle, saturation, brightness);
            return c;
        }
    }
}
