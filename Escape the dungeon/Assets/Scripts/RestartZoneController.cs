using UnityEngine;

public class RestartZoneController : MonoBehaviour
{
    [SerializeField]
    private Transform restartPos = null;

    private void OnTriggerEnter(Collider other)
    {
        PlayerMover player = other.gameObject.GetComponentInParent<PlayerMover>();
        if (player != null)
        {
            other.gameObject.transform.position = restartPos.position;
        }
    }
}
