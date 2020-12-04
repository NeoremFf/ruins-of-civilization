using UnityEngine;
using elementsEnym = ElementsCore.Elements;

public class PlayerElements : MonoBehaviour
{
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
                Color32 color = new Color32();
                var parts = GetComponentsInChildren<ParticleSystem>(true);
                if (ElementsCore.GetColorOfElement(currentElement, out color))
                {                
                    foreach (var item in parts)
                    {
                        if (!item.gameObject.activeSelf) item.gameObject.SetActive(true);
                        ParticleSystem.MainModule m = item.main;
                        m.startColor = (Color)color;
                    }
                }
                else
                {                   
                    foreach (var item in parts)
                    {
                        item.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
    private elementsEnym currentElement = elementsEnym.Water;
}
