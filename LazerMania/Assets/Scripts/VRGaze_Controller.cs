using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRGaze_Controller : MonoBehaviour
{
    public Image imgGaze;
    public float totalTime = 2;
    public bool gvrStatus;
    float gvrTimer;
    public bool walkToggle = false;
    public int WalkSpeed;

    public int distanceOfRay = 100;
    private RaycastHit _hit;

    [SerializeField] GameObject player;

    [SerializeField] Walk_Control walkControl;
    [SerializeField] Radio_Control radioControl;
    [SerializeField] Daytime_Control daytimeControl;
    [SerializeField] Bath_Onsen_Control bathOnsenControl;
    [SerializeField] Seat_Control seatControl;
    [SerializeField] Drinking_Control drinkingControl;
    [SerializeField] Change_Scene_Control changeSceneControl;

    [SerializeField] bool isWalking = false;
    [SerializeField] bool radioPlay = false;
    [SerializeField] bool daytime = true;
    [SerializeField] bool inOnsenBath = false;
    [SerializeField] bool sat = false;
    [SerializeField] bool drinking = false;
    [SerializeField] bool toOut = false; //to yard == true; to room == false

    // Start is called before the first frame update
    void Start()
    {
        imgGaze.fillAmount = 0;
        walkToggle = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit _hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));


        if (gvrStatus && Physics.Raycast(ray, out _hit, distanceOfRay))
        {
            gvrTimer += Time.deltaTime;
            imgGaze.fillAmount = gvrTimer / totalTime;

            if (isWalking == true)
            {
                walkControl.pause();
            }
        }

        if (Physics.Raycast(ray, out _hit, distanceOfRay))
        {
            Debug.Log(_hit.collider.tag);
            if (imgGaze.fillAmount == 1 && _hit.collider.CompareTag("Walk"))
            {
                if (isWalking == false)
                {
                    GVROff();
                    isWalking = walkControl.move();

                }
                else
                {
                    GVROff();
                    isWalking = walkControl.stop();
                }
            }

            if (imgGaze.fillAmount == 1 && _hit.collider.CompareTag("Radio"))
            {
                if(radioPlay == false)
                {
                    GVROff();
                    radioPlay = radioControl.turnOnRadio();

                }
                else
                {
                    GVROff();
                    radioPlay = radioControl.turnOffRadio();
                }
                
            }

            if (imgGaze.fillAmount == 1 && _hit.collider.CompareTag("Daytime"))
            {
                if (daytime == false)
                {
                    GVROff();
                    daytime = daytimeControl.sunrise();

                }
                else
                {
                    GVROff();
                    daytime = daytimeControl.sunset();
                }

            }

            if (imgGaze.fillAmount == 1 && _hit.collider.CompareTag("Onsen") && inOnsenBath == false && sat == false)
            {
                if (inOnsenBath == false)
                {
                    if (isWalking == true)
                    {
                        GVROff();
                        isWalking = walkControl.stop();

                    }

                    GVROff();
                    inOnsenBath = bathOnsenControl.enterBath();

                }
            }

            if (imgGaze.fillAmount == 1 && _hit.collider.CompareTag("Seat") && inOnsenBath == false && sat == false)
            {
                if (sat == false)
                {
                    if (isWalking == true)
                    {
                        GVROff();
                        isWalking = walkControl.stop();

                    }

                    GVROff();
                    sat = seatControl.sit(_hit.transform.gameObject);
                }
            }

            if (imgGaze.fillAmount == 1 && _hit.collider.CompareTag("Alcohol"))
            {
                if (drinking == false)
                {
                    GVROff();

                    drinking = true;

                    drinkingControl.drink(_hit.transform.gameObject);

                    drinking = false;
                }
            }

            if (imgGaze.fillAmount == 1 && _hit.collider.CompareTag("Door"))
            {
                if (toOut == true)
                    changeSceneControl.toYard();
                else
                    changeSceneControl.toRoom();
            }

            if (imgGaze.fillAmount == 1 && _hit.collider.CompareTag("LeavePoint"))
            {
                if (inOnsenBath == true)
                {
                    GVROff();
                    inOnsenBath = bathOnsenControl.leaveBath();

                }

                if (sat == true)
                {
                    GVROff();
                    sat = seatControl.leaveSeat();

                }
            }

        }

        player.transform.position = player.transform.position + Camera.main.transform.forward * WalkSpeed * Time.deltaTime;
    }

    public void GVROn()
    {
        gvrStatus = true;
    }

    public void GVROff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;

        if (isWalking == true)
        {
            walkControl.conti();
        }
    }

}