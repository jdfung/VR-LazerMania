using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio_Control : MonoBehaviour
{
    [SerializeField]
    private AudioSource track;

    public bool turnOnRadio()
    {
        track.Play();
        return true;
    }

    public bool turnOffRadio()
    {
        track.Stop();
        return false;
    }
}
