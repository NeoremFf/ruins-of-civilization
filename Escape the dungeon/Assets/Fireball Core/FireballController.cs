using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    [SerializeField]
    [Min(0.01f)]
    private float speed;

    public void SetDirection(Vector3 dir)
    {
        transform.forward = dir;
    }

    private void OnEnable()
    {
        StartCoroutine(DeactiveObject());
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<PlayerMoverWASD>() != null)
        {
            StopAllCoroutines();
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    private IEnumerator DeactiveObject()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}
