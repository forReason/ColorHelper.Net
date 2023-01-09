# ColorHelper.Net
ColorHelper.Net is a library for generating, converting, and mixing colors in C# .Net. It provides a simple and intuitive interface for working with colors in your .Net projects.

Features
- Generate colors using predefined color names, hex codes or random
- Convert colors between different color namespaces (eg. system.drawing.common)
- Mix colors
- Lighten or darken colors by a specific amount

## Installation
To install ColorHelper.Net, you can either clone the repository and build it yourself, or you can use NuGet to install the latest release.

To install using NuGet, run the following command in the Package Manager Console:
```
Install-Package ColorHelper.Net
```
## Examples
Here is an example of how you might use the ColorConverter class in a C# program:
```
// Convert a System.Windows.Media.Color to a System.Drawing.Color
System.Windows.Media.Color mediaColor = System.Windows.Media.Colors.Red;
System.Drawing.Color drawingColor = ColorConverter.ConvertColor(mediaColor);

// Convert a hex string to a System.Windows.Media.Color
string hex = "#FF0000"; // red
System.Windows.Media.Color color = ColorConverter.FromHex(hex);

// Convert a System.Drawing.Color to a hue, saturation, and value (HSV)
System.Drawing.Color c = System.Drawing.Color.FromArgb(255, 0, 0); // red
double hue, saturation, value;
ColorConverter.ColorToHSV(c, out hue, out saturation, out value);

// Convert a hue, saturation, and value (HSV) to a System.Drawing.Color
System.Drawing.Color newColor = ColorConverter.ColorFromHSV(hue, saturation, value);
```

Here is an example of how you might use the ColorMixer class in a C# program:
```
// Create an array of ColorAmount objects representing different colors and volumes
ColorAmount[] colorDrops = new ColorAmount[3];
colorDrops[0] = new ColorAmount(System.Drawing.Color.FromArgb(255, 255, 0, 0), 50); // red, 50% volume
colorDrops[1] = new ColorAmount(System.Drawing.Color.FromArgb(255, 0, 255, 0), 25); // green, 25% volume
colorDrops[2] = new ColorAmount(System.Drawing.Color.FromArgb(255, 0, 0, 255), 75); // blue, 75% volume

// Mix the colors together
System.Drawing.Color mixedColor = ColorMixer.MixColors(colorDrops);

// Create an array of ShiftColorAmount objects representing different shifted colors and volumes
ShiftColorAmount[] shiftColorDrops = new ShiftColorAmount[3];
shiftColorDrops[0] = new ShiftColorAmount(new ShiftColor(System.Drawing.Color.FromArgb(255, 255, 0, 0), 50, 0, 0), 50); // red, 50% hue shift, 50% volume
shiftColorDrops[1] = new ShiftColorAmount(new ShiftColor(System.Drawing.Color.FromArgb(255, 0, 255, 0), 0, 25, 0), 25); // green, 25% saturation shift, 25% volume
shiftColorDrops[2] = new ShiftColorAmount(new ShiftColor(System.Drawing.Color.FromArgb(255, 0, 0, 255), 0, 0, 75), 75); // blue, 75% value shift, 75% volume

// Mix the shifted colors together
ShiftColor mixedShiftColor = ColorMixer.MixShiftColors(shiftColorDrops);
```

Here is an example of how you might use the RandomColor class in a C# program:
```
// Generate a random color with a 20% chance of being one of the primary colors
System.Drawing.Color randomColor = RandomColor.Next(includeAlpha: false, primeColorChance: 0.2);

// Generate a random color with a random hue and saturation based on the base color red, with a saturation of 50% and brightness of 100%
System.Drawing.Color randomHueSaturationColor = RandomColor.Next(RGB_BasicColors.Red, 0.5, 1.0);
```
