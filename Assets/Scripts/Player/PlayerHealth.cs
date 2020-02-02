using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    Transform bar;

    // Start is called before the first frame update
    void Start()
    {
        bar = gameObject.transform.Find("Healthbackground2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
