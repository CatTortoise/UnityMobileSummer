using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMenager : MonoBehaviour
{
    [SerializeField] Camera mineCamra;
    [SerializeField] GameObject gameObject;
    [SerializeField] Hello hello;
    // Update is called once per frame
    void Update()
    {
        //if (Input.touchSupported)
        {

            Touch[] inputs = Input.touches;
            if (inputs.Length > 0)
            {
                for (int i = 0; i < inputs.Length; i++)
                {
                    hello.SetTexst(inputs[i].phase.ToString());
                    if (inputs[i].phase == TouchPhase.Ended)
                    {
                        Vector3 vec = mineCamra.ScreenToWorldPoint(inputs[i].position);
                        hello.SetTexst(vec.ToString());
                        gameObject.transform.position = new Vector3( vec.x, vec.y,0);
                        
                    }
                }
            }
        }
    }
}
