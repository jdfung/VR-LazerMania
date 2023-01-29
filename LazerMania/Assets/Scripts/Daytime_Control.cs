using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daytime_Control : MonoBehaviour
{
    [SerializeField] private GameObject [] sunLight;
    [SerializeField] private GameObject [] lights;

    public bool sunrise()
    {
        for (int i = 0; i < sunLight.Length; i++)
            sunLight[i].SetActive(true);

        for (int i = 0; i < lights.Length; i++)
            lights[i].SetActive(false);

        return true;
    }

    public bool sunset()
    {
        for (int i = 0; i < sunLight.Length; i++)
            sunLight[i].SetActive(false);

        for (int i = 0; i < lights.Length; i++)
            lights[i].SetActive(true);

        return false;
    }
}
