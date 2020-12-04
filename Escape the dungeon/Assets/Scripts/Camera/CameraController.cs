using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Vector3 offset = Vector3.zero;
    private Transform player = null;
    private Vector3 orgRotation;


    private bool isCameraFollowPlayer = true;

    private void Start()
    {
        player = FindObjectOfType<PlayerMover>().gameObject.GetComponentInChildren<Rigidbody>().gameObject.transform;
        orgRotation = this.transform.rotation.eulerAngles;
    }

    public void SetCameraPosition(Transform transform, Vector3 quaternion)
    {
        isCameraFollowPlayer = false;
        this.transform.position = transform.position;
        

        StartCoroutine(AnimCameraMove(transform, quaternion));
    }

    private IEnumerator AnimCameraMove(Transform transform, Vector3 quaternion)
    {
        float time = .0f;
        float t = 0;
        this.transform.rotation = Quaternion.Euler(quaternion);
        while (t < time)
        {
            t += Time.deltaTime;
            this.transform.rotation = Quaternion.Lerp(Quaternion.Euler(orgRotation), Quaternion.Euler(quaternion), t / time);
            //this.transform.Rotate(rot, Space.World);
            yield return null;
        }
    }

    public void ResetCameraPosition()
    {
        StopAllCoroutines();
        isCameraFollowPlayer = true;
        transform.rotation = Quaternion.Euler(orgRotation);
    }

    void Update()
    {
        if (isCameraFollowPlayer)
            transform.position = player.transform.position + offset;
    }
}
