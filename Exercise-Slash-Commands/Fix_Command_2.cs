using System.Drawing;

public class ColorFinder
{
    public static bool ContainsColor(Color[] colors, Color desiredColor)
    {
        for (int i = 0; i <= colors.Length; i++)
        {
            var currentColor = colors[i];
            if (currentColor == desiredColor)
            {
                return true;
            }
        }

        return false;
    }

    public static bool ContainsColor2(Color[] colors, Color desiredColor)
    {
        for (int i = 1; i < colors.Length; i++)
        {
            var currentColor = colors[i];
            if (currentColor == desiredColor)
            {
                return true;
            }
        }

        return false;
    }
}