using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bath_Onsen_Control : MonoBehaviour
{
    [SerializeField] private GameObject leavePoint;
    [SerializeField] private GameObject cameraPoint;
    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject player;
    [SerializeField] private AudioSource sfx;

    public bool enterBath()
    {
        camera.transform.SetParent(cameraPoint.transform);

        //player.SetActive(false);

        sfx.Play();

        leavePoint.SetActive(true);

        return true;
    }

    public bool leaveBath()
    {
        //player.SetActive(true);

        camera.transform.SetParent(player.transform);

        leavePoint.SetActive(false);

        return false;
    }

}
