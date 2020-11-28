using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballsCoreController : MonoBehaviour
{
    [SerializeField]
    private GameObject fireballPref = null;
    [SerializeField]
    private Transform poolGO = null;
    private GameObject[] fireballPool = new GameObject[4];

    private void Start()
    {
        for (int i = 0; i < fireballPool.Length; i++)
        {
            fireballPool[i] = Instantiate(fireballPref);
            fireballPool[i].transform.SetParent(poolGO);
            fireballPool[i].GetComponent<FireballController>()?.SetDirection(transform.forward);
            fireballPool[i].SetActive(false);
        }

        StartCoroutine(SpawnFireball());
    }

    private IEnumerator SpawnFireball()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            foreach (var item in fireballPool)
            {
                if (item.activeSelf == false)
                {
                    item.transform.position = transform.position;
                    item.SetActive(true);
                    break;
                }
            }
        }
    }
}
