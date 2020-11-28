using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Vector3 offset = Vector3.zero;
    private Transform player = null;

    private void Start()
    {
        player = FindObjectOfType<PlayerMover>()?.gameObject.transform;
        offset = new Vector3(4, 13.75f, -4);
        if (player == null)
        {
            player = FindObjectOfType<PlayerMoverWASD>().gameObject.GetComponentInChildren<Rigidbody>().gameObject.transform;
            offset = new Vector3(0, 13.3f, -1.6f);
        }
    }
    
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
