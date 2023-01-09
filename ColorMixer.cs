using Statistics.Average_NS;
using System.Drawing;

namespace ColorHelper
{
    /// <summary>
    /// colormixer can mix multiple colors based on their volume
    /// </summary>
    public class ColorMixer
    {
        /// <summary>
        /// mixes multiple colors together
        /// </summary>
        /// <param name="colorDrops"></param>
        /// <returns></returns>
        public static Color MixColors(ColorAmount[] colorDrops)
        {
            VolumetricValue[] reds = new VolumetricValue[colorDrops.Length];
            VolumetricValue[] greens = new VolumetricValue[colorDrops.Length];
            VolumetricValue[] blues = new VolumetricValue[colorDrops.Length];
            VolumetricValue[] alphas = new VolumetricValue[colorDrops.Length];
            //for (int i = 0; i < colorDrops.Length; i++)
            //{
            //    reds[i] = new VolumetricValue(value: colorDrops[i].Color.R* (colorDrops[i].Volume / 255), (colorDrops[i].Volume/255) * colorDrops[i].Color.R);
            //    greens[i] = new VolumetricValue(value: colorDrops[i].Color.G* (colorDrops[i].Volume / 255), (colorDrops[i].Volume / 255) * colorDrops[i].Color.G);
            //    blues[i] = new VolumetricValue(value: colorDrops[i].Color.B* (colorDrops[i].Volume / 255), (colorDrops[i].Volume / 255) * colorDrops[i].Color.B);
            //    alphas[i] = new VolumetricValue(value: colorDrops[i].Color.A, colorDrops[i].Volume);
            //}
            for (int i = 0; i < colorDrops.Length; i++)
            {
                reds[i] = new VolumetricValue(value: colorDrops[i].Color.R, (colorDrops[i].Volume / 255) * colorDrops[i].Color.R);
                greens[i] = new VolumetricValue(value: colorDrops[i].Color.G, (colorDrops[i].Volume / 255) * colorDrops[i].Color.G);
                blues[i] = new VolumetricValue(value: colorDrops[i].Color.B, (colorDrops[i].Volume / 255) * colorDrops[i].Color.B);
                alphas[i] = new VolumetricValue(value: colorDrops[i].Color.A, colorDrops[i].Volume);
            }
            int red = (int)Volumetric_Average.VolumeBasedAverage(reds);
            int green = (int)Volumetric_Average.VolumeBasedAverage(greens);
            int blue = (int)Volumetric_Average.VolumeBasedAverage(blues);
            int alpha = (int)Volumetric_Average.VolumeBasedAverage(alphas);
            return System.Drawing.Color.FromArgb(alpha, red, green, blue);
        }
        /// <summary>
        /// mixes multiple colors together
        /// </summary>
        /// <param name="colorDrops"></param>
        /// <returns></returns>
        public static ShiftColor MixShiftColors(ShiftColorAmount[] colorDrops)
        {
            ColorAmount[] r = new ColorAmount[colorDrops.Length];
            ColorAmount[] g = new ColorAmount[colorDrops.Length];
            ColorAmount[] b = new ColorAmount[colorDrops.Length];
            for (int i = 0; i < colorDrops.Length; i++)
            {
                r[i] = new ColorAmount(colorDrops[i].Color.Red_channel, colorDrops[i].Volume);
                g[i] = new ColorAmount(colorDrops[i].Color.Green_channel, colorDrops[i].Volume);
                b[i] = new ColorAmount(colorDrops[i].Color.Blue_channel, colorDrops[i].Volume);
            }
            Color new_r = ColorMixer.MixColors(r);
            Color new_g = ColorMixer.MixColors(g);
            Color new_b = ColorMixer.MixColors(b);
            ShiftColor mixResult = new ShiftColor(new_r,new_g,new_b);
            return mixResult;
        }
        /// <summary>
        /// shifts a color based on thee shiftcolor
        /// </summary>
        /// <param name="baseColor"></param>
        /// <param name="shiftColor"></param>
        /// <returns></returns>
        public Color RecolorPixel(Color baseColor, ShiftColor shiftColor)
        {
            ColorAmount pixelColor_R = new ColorAmount(shiftColor.Red_channel, baseColor.R);
            ColorAmount pixelColor_G = new ColorAmount(shiftColor.Green_channel, baseColor.G);
            ColorAmount pixelColor_B = new ColorAmount(shiftColor.Blue_channel, baseColor.B);
            Color result = MixColors(new[] { pixelColor_R, pixelColor_G, pixelColor_G });
            return result;
        }
    }
}
