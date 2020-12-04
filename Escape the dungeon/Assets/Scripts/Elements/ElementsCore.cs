using UnityEngine;
public class ElementsCore
{
    public enum Elements
    {
        Fire,
        Water,
        Air,
        Earth,
        None
    }

    private static Color32[] ColorOfElements = new Color32[]
    {
            new Color32(240, 45, 45, 255),   // fire
            new Color32(45, 45, 240, 255),   // water
            new Color32(220, 240, 250, 255), // air
            new Color32(235, 125, 25, 255),  // earth
            new Color32()                    // none
    };

    public static bool GetColorOfElement(Elements elem, out Color32 color)
    {
        color = ColorOfElements[(int)elem];
        return elem != Elements.None;
    }
}
