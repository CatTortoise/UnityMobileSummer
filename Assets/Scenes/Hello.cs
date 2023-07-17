using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hello : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    // Start is called before the first frame update
    void Start()
    {
        _text.text = "Hello me";
    }

}
