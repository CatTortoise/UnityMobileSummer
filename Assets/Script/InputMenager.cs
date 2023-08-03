using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMenager : MonoBehaviour
{
    [SerializeField] Camera mineCamra;
    [SerializeField] GameObject gameObject;
    [SerializeField] LocationMarkerScript marker;

    void Update()
    {
        //if (Input.touchSupported)
        {

            Touch[] inputs = Input.touches;
            if (inputs.Length > 0)
            {
                for (int i = 0; i < inputs.Length; i++)
                {
                    if (inputs[i].phase == TouchPhase.Began)
                    {
                        Vector3 vec = mineCamra.ScreenToWorldPoint(inputs[i].position);
                        gameObject.transform.position = new Vector3( vec.x, vec.y,0);
                        marker.ChangeLocation(gameObject.transform.position);
                    }
                }
            }
        }
    }


}
