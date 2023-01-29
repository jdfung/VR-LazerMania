using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights_Control : MonoBehaviour
{
    public bool lights_OnOff = true;
    public Light light1;
    public Light light2;
    public Light light3;
    // Start is called before the first frame update
    void Start()
    {
        //light1 = GetComponent<Light>();
        //light2 = GetComponent<Light>();
        //light3 = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {

        if(lights_OnOff)
        {
            light1.enabled = true;
            light2.enabled = true;
            light3.enabled = true;
        }
        else
        {
            light1.enabled = false;
            light2.enabled = false;
            light3.enabled = false;
        }
    }
}
