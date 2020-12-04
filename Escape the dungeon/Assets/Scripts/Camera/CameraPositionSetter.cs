using UnityEngine;

public class CameraPositionSetter : MonoBehaviour
{
    [Header("GameObjects to control")]
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private CameraController cameraController = null;

    [Header("GameObjects to control")]
    [SerializeField]
    private Vector3 playerForward;

    [Header("Camera Settings")]
    [SerializeField]
    private Transform cameraPos = null;
    [SerializeField]
    private Vector3 cameraQuaternion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<PlayerMover>() != null)
        {
            cameraController.SetCameraPosition(cameraPos, cameraQuaternion);
            playerTransform.rotation = Quaternion.Euler(playerForward);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<PlayerMover>() != null)
        {
            cameraController.ResetCameraPosition();
            playerTransform.forward = Vector3.forward;
        }
    }
}
