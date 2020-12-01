using UnityEngine;

public class ElementalChangeTotemController : MonoBehaviour
{
    [SerializeField]
    private ElementsCore.Elements elementOfTotem = ElementsCore.Elements.Water;

    private GameObject pressButtonUI = null;

    private PlayerElements playerNearby = null;

    private void Start()
    {
        pressButtonUI = GetComponentInChildren<Canvas>().gameObject;
    }

    private void Update()
    {
        if (playerNearby != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
                playerNearby.CurrentElement = elementOfTotem;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        PlayerElements elem = other.gameObject.GetComponentInParent<PlayerElements>();
        if (elem != null)
        {
            Debug.Log("Player");
            pressButtonUI.SetActive(true);
            playerNearby = elem;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        PlayerElements elem = other.gameObject.GetComponentInParent<PlayerElements>();
        if (elem != null)
        {
            pressButtonUI.SetActive(false);
            playerNearby = null;
        }
    }
}
