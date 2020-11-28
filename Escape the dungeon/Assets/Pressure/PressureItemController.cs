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
    private bool alreadyStayed = false;

    private Transform player = null;

    private void Start()
    {
        player = FindObjectOfType<PlayerMover>()?.gameObject.transform;
        if (player == null) player = player = FindObjectOfType<PlayerMoverWASD>().gameObject.GetComponentInChildren<Rigidbody>().gameObject.transform;
        defaultMaterial = GetComponentInChildren<Renderer>().material;
    }

    public void ResetPressState()
    {
        alreadyPressed = false;
        GetComponentInChildren<Renderer>().material = defaultMaterial;
    }

    private void Update()
    {
        Vector3 dir = transform.position - player.position;
        if (!alreadyPressed)
        {
            if (dir.magnitude < 1f)
            {
                if (!alreadyStayed)
                {
                    Debug.Log("Player stay in the pressure: " + id);
                    alreadyStayed = true;
                    alreadyPressed = true;
                    core.PlayerPressed(id);

                    GetComponentInChildren<Renderer>().material = tempPressedMaterial;
                }
            }
            else
                alreadyStayed = false;
        }
    }
}
