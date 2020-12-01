using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseBridgePuzzleCore : MonoBehaviour
{
    [SerializeField]
    private Camera cameraToInteractive = null;
    [SerializeField]
    private LayerMask layerMaskToHit;

    [Header("Parts of Bridge")]
    [SerializeField]
    private BridgePartController[] partsOfBridge;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cameraToInteractive.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10, layerMaskToHit))
            {
                LeverController leverController = hit.collider.gameObject.GetComponent<LeverController>();
                if (leverController != null) ActPartsOfBridge(leverController.Id);
            }
        }
    }

    private void ActPartsOfBridge(int id)
    {
        switch (id)
        {
            case 0: // 5th
                partsOfBridge[0].SetState();
                partsOfBridge[4].SetState();
                break;
            case 1: // 1th
                partsOfBridge[1].SetState();
                partsOfBridge[3].SetState();
                break;
            case 2: // 4th
                partsOfBridge[0].SetState();
                partsOfBridge[1].SetState();
                partsOfBridge[2].SetState();
                partsOfBridge[4].SetState();
                break;
            case 3: // 2th
                partsOfBridge[2].SetState();
                partsOfBridge[3].SetState();
                partsOfBridge[4].SetState();
                break;
            case 4: // 3th
                partsOfBridge[0].SetState();
                partsOfBridge[1].SetState();
                partsOfBridge[2].SetState();
                partsOfBridge[3].SetState();
                break;
            default:
                break;
        }
    }
}
