using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField]
    private Animation openDoorAnimation = null;
    [SerializeField]
    private float openDoorAnimationSeconds = 0;
    private Animator animator = null;

    [Header("Sound")]
    [SerializeField]
    private AudioSource openDoorSound = null;

    private BoxCollider collider = null;

    public void OpenDoor()
    {
        Debug.Log("Door is open");
        animator = GetComponentInChildren<Animator>();
        animator.Play("Open");
        //openDoorSound.Play();
        StartCoroutine(DoorOpened());
    }

    private IEnumerator DoorOpened()
    {
        yield return new WaitForSeconds(openDoorAnimationSeconds);
        collider = GetComponentInChildren<BoxCollider>();
        if (collider != null) collider.isTrigger = true;
    }
}
