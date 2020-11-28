using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoverWASD : MonoBehaviour
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

        rb.velocity = new Vector3(moveX, rb.velocity.y, moveZ);
        rb.velocity = rb.velocity.normalized * 10;
    }
}
