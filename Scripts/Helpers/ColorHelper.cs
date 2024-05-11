using Godot;

namespace SurfaceToolDemo.Scripts.Helpers
{
    public static class ColorHelper
    {
        public static Color GetRandomColor(bool randAlpha = false)
        {
            var randColor = new Color();
            var rng = new RandomNumberGenerator();
            randColor.R8 = rng.RandiRange(0, 255);
            randColor.G8 = rng.RandiRange(0, 255);
            randColor.B8 = rng.RandiRange(0, 255);
            if (randAlpha)
            {
                randColor.A8 = rng.RandiRange(0, 255);
            }
            else
            {
                randColor.A8 = 255;
            }
            return randColor;
        }
    }
}
