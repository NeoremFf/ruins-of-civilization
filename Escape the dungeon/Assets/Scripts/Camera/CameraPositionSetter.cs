using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionSetter : MonoBehaviour
{
    [SerializeField]
    private CameraController cameraController = null;
    [SerializeField]
    private Transform cameraPos = null;
    [SerializeField]
    private Vector3 cameraQuaternion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<PlayerMover>() != null)
            cameraController.SetCameraPosition(cameraPos, cameraQuaternion);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<PlayerMover>() != null)
            cameraController.ResetCameraPosition();
    }
}
