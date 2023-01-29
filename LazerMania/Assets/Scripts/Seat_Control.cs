using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seat_Control : MonoBehaviour
{
    private GameObject seat;   
    private GameObject cameraPoint;
    private AudioSource sfx;

    [SerializeField] private GameObject leavePoint;
    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject player;

    public bool sit(GameObject targetSeat)
    {
        seat = targetSeat.transform.parent.gameObject;
        cameraPoint = seat.transform.GetChild(1).gameObject;
        sfx = seat.GetComponent<AudioSource>();

        camera.transform.SetParent(cameraPoint.transform);

        //player.SetActive(false);

        sfx.Play();

        leavePoint.SetActive(true);

        return true;
    }

    public bool leaveSeat()
    {
        //player.SetActive(true);

        camera.transform.SetParent(player.transform);

        leavePoint.SetActive(false);

        return false;
    }

}
