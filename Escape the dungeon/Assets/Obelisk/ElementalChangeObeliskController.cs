using UnityEngine;
using elementEnum = ElementsCore.Elements;

public class ElementalChangeObeliskController : MonoBehaviour
{
    [SerializeField]
    private elementEnum elementOfObelisk;
    private elementEnum element
    {
        get
        {
            return elementOfObelisk;
        }

        set
        {
            if (elementOfObelisk != value)
            {
                elementOfObelisk = value;
                SetColorEffects();
            }
        }
    }

    private GameObject pressButtonUI = null;

    private PlayerElements playerNearby = null;

    private void Start()
    {
        pressButtonUI = GetComponentInChildren<Canvas>().gameObject;
        pressButtonUI.SetActive(false);

        SetColorEffects();
    }

    private void Update()
    {
        if (playerNearby != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                playerNearby.CurrentElement = ElementalSwap(playerNearby.CurrentElement);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerElements elem = other.gameObject.GetComponentInParent<PlayerElements>();
        if (elem != null)
        {
            pressButtonUI.SetActive(true);
            playerNearby = elem;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerElements elem = other.gameObject.GetComponentInParent<PlayerElements>();
        if (elem != null)
        {
            pressButtonUI.SetActive(false);
            playerNearby = null;
        }
    }

    private elementEnum ElementalSwap(elementEnum player)
    {
        elementEnum temp = element;
        element = player;
        return temp;
    }

    private void SetColorEffects()
    {
        Color32 color = new Color32();
        if (ElementsCore.GetColorOfElement(elementOfObelisk, out color))
        {
            SetParticlesColor(color);
            SetLightColor(color);
        }
        else
        {
            SetParticlesColor(color, false);
            SetLightColor(color, false);
        }
    }

    private void SetLightColor(Color32 color, bool active = true)
    {
        var light = GetComponentInChildren<Light>(true);
        light.gameObject.SetActive(active);
        light.color = color;
    }

    private void SetParticlesColor(Color color, bool active = true)
    {     
        var part = GetComponentInChildren<ParticleSystem>(true);
        part.gameObject.SetActive(active);
        var mainPart = part.main;
        mainPart.startColor = color;
    }
}
