using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private Rigidbody rb = null;

    private void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
    }

    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        float velocityY = rb.velocity.y;

        rb.velocity = new Vector3(moveX, rb.velocity.y, moveZ);
        Vector3 velocityNormal = rb.velocity.normalized * 10;
        rb.velocity = new Vector3(velocityNormal.x, velocityY, velocityNormal.z);
    }
}
