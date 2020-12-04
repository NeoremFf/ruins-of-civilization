using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureItemController : MonoBehaviour
{
    [SerializeField]
    private Material tempPressedMaterial = null;
    private Material defaultMaterial = null;

    [SerializeField]
    private PressureCoreManager core = null;

    [SerializeField]
    private int id = -1;

    private bool alreadyPressed = false;

    private void Start()
    {
        defaultMaterial = GetComponentInChildren<Renderer>().material;
    }

    public void ResetPressState()
    {
        alreadyPressed = false;
        GetComponentInChildren<Renderer>().material = defaultMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<PlayerMover>() != null)
        {
            if (!alreadyPressed)
            {
                StartCoroutine(PlayerPress());
            }
        }
    }

    private IEnumerator PlayerPress()
    {
        alreadyPressed = true;
        GetComponentInChildren<Renderer>().material = tempPressedMaterial;
        yield return new WaitForEndOfFrame();
        core.PlayerPressed(id);
    }
}
