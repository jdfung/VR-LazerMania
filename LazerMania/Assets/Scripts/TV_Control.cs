using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TV_Control : MonoBehaviour
{
    public bool tv_OnOff = false;
    private VideoPlayer vp;

    // Start is called before the first frame update
    void Start()
    {
        vp = gameObject.GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (tv_OnOff)
        {
            vp.Play();
        }
        else
        {
            vp.Stop();
        }
    }
}
