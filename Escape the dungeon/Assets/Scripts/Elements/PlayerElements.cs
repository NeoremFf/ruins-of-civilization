using UnityEngine;
using elementsEnym = ElementsCore.Elements;

public class PlayerElements : MonoBehaviour
{
    [System.Obsolete]
    public elementsEnym CurrentElement
    {
        get
        {
            return currentElement;
        }

        set
        {
            if (currentElement != value)
            {
                currentElement = value;
                Color color = ElementsCore.GetColorOfElement(currentElement);
                var parts = GetComponentsInChildren<ParticleSystem>();
                foreach (var item in parts)
                    item.startColor = color;
            }
        }
    }

    private elementsEnym currentElement = elementsEnym.Water;
}
