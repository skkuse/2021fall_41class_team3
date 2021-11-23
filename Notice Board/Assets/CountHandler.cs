using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountHandler : MonoBehaviour
{   
    public string GetValue()
    {
        Text txt = transform.Find("Text").GetComponent<Text>();
        return txt.text;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
