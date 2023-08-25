using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetileKiller : MonoBehaviour
{

    
    private void OnEnable()
    {
        StartCoroutine(WaitFor());
    }

    IEnumerator WaitFor()
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }


}
