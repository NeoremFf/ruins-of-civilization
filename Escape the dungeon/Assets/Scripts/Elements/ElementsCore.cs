using UnityEngine;
public class ElementsCore
{
    public enum Elements
    {
        Fire,
        Water,
        Air,
        Earth
    }

    private static Color[] ColorOfElements = new Color[4]
    {
            new Color(240, 45, 45, 255),   // fire
            new Color(45, 45, 240, 255),   // water
            new Color(220, 240, 250, 255), // air
            new Color(235, 125, 25, 255)   // earth
    };

    public static Color GetColorOfElement(Elements elem)
    {
        return ColorOfElements[(int)elem];
    }
}
