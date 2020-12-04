using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private Rigidbody rb = null;

    private Transform playerTransform;

    private void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();

        playerTransform = rb.gameObject.transform;
    }

    private void FixedUpdate()
    {
        Vector3 moveX = Input.GetAxisRaw("Horizontal") * playerTransform.right;
        Vector3 moveZ = Input.GetAxisRaw("Vertical") * playerTransform.forward;
        float velocityY = rb.velocity.y;

        rb.velocity = moveX + moveZ;
        Vector3 velocityNormal = rb.velocity.normalized * 10;
        rb.velocity = new Vector3(velocityNormal.x, velocityY, velocityNormal.z);
    }
}
