using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Vector3 offset = Vector3.zero;
    private Transform player = null;
    private Vector3 rotationToPlayer;


    private bool isCameraFollowPlayer = true;

    private void Start()
    {
        player = FindObjectOfType<PlayerMover>().gameObject.GetComponentInChildren<Rigidbody>().gameObject.transform;
        rotationToPlayer = transform.rotation.eulerAngles;
    }

    public void SetCameraPosition(Transform transform, Vector3 quaternion)
    {
        isCameraFollowPlayer = false;
        this.transform.position = transform.position;
        

        StartCoroutine(AnimCameraMove(transform, quaternion));
    }

    private IEnumerator AnimCameraMove(Transform transform, Vector3 quaternion)
    {
        float time = 2f;
        float t = 0;
        while (t < time)
        {
            t += Time.deltaTime;
            Debug.Log(t);
            Vector3 rot = Vector3.Lerp(rotationToPlayer, quaternion, t / time);
            this.transform.Rotate(rot, Space.World);
            yield return null;
        }
    }

    public void ResetCameraPosition()
    {
        isCameraFollowPlayer = true;
        transform.Rotate(rotationToPlayer, Space.World);
    }

    void Update()
    {
        if (isCameraFollowPlayer)
            transform.position = player.transform.position + offset;
    }
}
