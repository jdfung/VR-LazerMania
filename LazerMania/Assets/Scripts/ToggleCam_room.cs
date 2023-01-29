using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCam_room : MonoBehaviour
{
    public Transform mainCam;
    public Transform seatedCam1;
    public Transform seatedCam2;
    public Transform futonCam;
    public float sSpeed = 10.0f;
    public Vector3 dist;
    public Transform lookTarget;
    public bool isSeated = false;
    public bool isLaidDown = false;

    public int currentCam;
    private Transform cameraTarget;

    public GameObject returnPoint;
    public GameObject playerMove;

    void Start()
    {
        currentCam = 1;
        SetCameraTarget(currentCam);
        
    }

    void FixedUpdate()
    {
        Vector3 dPos = cameraTarget.position + dist;
        Vector3 sPos = Vector3.Lerp(transform.position, dPos, sSpeed * Time.deltaTime);
        transform.position = sPos;
           
     }


    public void SetCameraTarget(int num)
    {
        switch (num) {
            case 1:
                cameraTarget = mainCam.transform;
                break;
            case 2:
                cameraTarget = seatedCam1.transform;
                break;
            case 3:
                cameraTarget = seatedCam2.transform;
                break;

            case 4:
                cameraTarget = futonCam.transform;
                break;
        }
    }

    public void SwitchCamera()
    {
        if(currentCam < 4)
        {
            currentCam++;
        }
        else
        {
            currentCam = 1;
        }
        SetCameraTarget(currentCam);
    }

    // Update is called once per frame
    void Update()
    {
        SetCameraTarget(currentCam);

        if(currentCam == 2 || currentCam == 3)
        {
            isSeated = true;
            returnPoint.SetActive(true);
            playerMove.SetActive(false);
        }
        else if(currentCam == 4)
        {
            isLaidDown = true;
            returnPoint.SetActive(true);
            playerMove.SetActive(false);
        }
        else
        {
            isSeated = false;
            isLaidDown = false;
            returnPoint.SetActive(false);
            playerMove.SetActive(true);
        }
    }
}
