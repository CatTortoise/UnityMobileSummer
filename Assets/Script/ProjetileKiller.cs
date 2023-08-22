using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetileKiller : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(WaitFor());
    }

    IEnumerator WaitFor()
    {
        yield return new WaitForSeconds(5);
        Object.Destroy(this.gameObject);
    }
}
