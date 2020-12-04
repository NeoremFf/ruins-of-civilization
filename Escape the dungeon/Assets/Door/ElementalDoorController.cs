using UnityEngine;
using elementEnum = ElementsCore.Elements;

public class ElementalDoorController : MonoBehaviour
{
    [SerializeField]
    private elementEnum doorElement;

    private void OnCollisionEnter(Collision col)
    {
        PlayerElements playerElem = col.gameObject.GetComponentInParent<PlayerElements>();
        if (playerElem != null && playerElem.CurrentElement == doorElement)
        {
            Destroy(gameObject);
            //this.GetComponent<Collider>().isTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerElements playerElem = other.gameObject.GetComponentInParent<PlayerElements>();
        if (playerElem != null)
            this.GetComponent<Collider>().isTrigger = false;
    }
}
