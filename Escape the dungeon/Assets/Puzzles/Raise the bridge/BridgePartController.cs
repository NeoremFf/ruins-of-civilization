using UnityEngine;

public class BridgePartController : MonoBehaviour
{
    private bool state = false;

    public void SetState()
    {
        state = !state;
        if (state)
            transform.position += Vector3.up * 10;
        else
            transform.position -= Vector3.up * 10;
    }
}
