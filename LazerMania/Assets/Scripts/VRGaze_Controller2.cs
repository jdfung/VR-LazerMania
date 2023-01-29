using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRGaze_Controller2 : MonoBehaviour
{

    //Player configurations
    public Image imgGaze;
    public float totalTime = 1;
    public bool gvrStatus;
    float gvrTimer;
    public bool walkToggle = false;
    public int WalkSpeed;
    public int distanceOfRay = 100;
    private RaycastHit _hit;

    //other scripts
    public GameObject television;
    public GameObject light;
    public GameObject playerCam;

    //Door
    [SerializeField] Change_Scene_Control changeSceneControl;
    [SerializeField] bool toOut = false; //to yard == true; to room == false

    // Start is called before the first frame update
    void Start()
    {
        imgGaze.fillAmount = 0;
        walkToggle = false;

        //Reference needed gameobject
        television = GameObject.Find("TV_screen");
        light = GameObject.Find("lightSources");
        playerCam = GameObject.Find("CameraHolder");
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));


        if (gvrStatus && Physics.Raycast(ray, out _hit, distanceOfRay))
        {
            gvrTimer += Time.deltaTime;
            imgGaze.fillAmount = gvrTimer / totalTime;
            //gameObject.GetComponent<Walk_Toggle>().walkToggle = false;
            gameObject.GetComponent<Walk_Toggle>().WalkSpeed = 0;
            StartCoroutine(waiter());

        }

        if (Physics.Raycast(ray, out _hit, distanceOfRay))
        {
            Debug.Log(_hit.collider.tag);
            if (imgGaze.fillAmount == 1 && _hit.collider.CompareTag("Walk"))
            {
                GVROff();
                gameObject.GetComponent<Walk_Toggle>().toggleWalk(); 
            }

            if (imgGaze.fillAmount == 1 && _hit.collider.CompareTag("Television"))
            {
                GVROff();
                television.GetComponent<TV_Control>().tv_OnOff = !television.GetComponent<TV_Control>().tv_OnOff;
            }

            if (imgGaze.fillAmount == 1 && _hit.collider.CompareTag("light_switch"))
            {
                GVROff();
                light.GetComponent<Lights_Control>().lights_OnOff = !light.GetComponent<Lights_Control>().lights_OnOff;
            }

            if (imgGaze.fillAmount == 1 && _hit.collider.CompareTag("futonSeat"))
            {
                GVROff();
                playerCam.GetComponent<ToggleCam_room>().currentCam = 2;
                playerCam.GetComponent<ToggleCam_room>().SetCameraTarget(playerCam.GetComponent<ToggleCam_room>().currentCam);
                if (playerCam.GetComponent<ToggleCam_room>().isSeated)
                {
                    gameObject.GetComponent<Walk_Toggle>().toggleWalk();
                }
            }

            if (imgGaze.fillAmount == 1 && _hit.collider.CompareTag("futonSeat2"))
            {
                GVROff();
                playerCam.GetComponent<ToggleCam_room>().currentCam = 3;
                playerCam.GetComponent<ToggleCam_room>().SetCameraTarget(playerCam.GetComponent<ToggleCam_room>().currentCam);

                if (playerCam.GetComponent<ToggleCam_room>().isSeated)
                {
                    gameObject.GetComponent<Walk_Toggle>().toggleWalk();
                }
            }

            if (imgGaze.fillAmount == 1 && _hit.collider.CompareTag("futonBed"))
            {
                GVROff();
                playerCam.GetComponent<ToggleCam_room>().currentCam = 4;
                playerCam.GetComponent<ToggleCam_room>().SetCameraTarget(playerCam.GetComponent<ToggleCam_room>().currentCam);

                if (playerCam.GetComponent<ToggleCam_room>().isLaidDown)
                {
                    gameObject.GetComponent<Walk_Toggle>().toggleWalk();
                }
            }

            if (imgGaze.fillAmount == 1 && _hit.collider.CompareTag("Return"))
            {
                GVROff();
                playerCam.GetComponent<ToggleCam_room>().currentCam = 1;
                playerCam.GetComponent<ToggleCam_room>().SetCameraTarget(playerCam.GetComponent<ToggleCam_room>().currentCam);
            }

            if (imgGaze.fillAmount == 1 && _hit.collider.CompareTag("food"))
            {
                GVROff();
                _hit.collider.GetComponent<PickUp_Controller>().isFood = true;
                StartCoroutine(_hit.collider.GetComponent<PickUp_Controller>().holdItem());
            }
            if (imgGaze.fillAmount == 1 && _hit.collider.CompareTag("drinks"))
            {
                GVROff();
                _hit.collider.GetComponent<PickUp_Controller>().isFood = false;
                StartCoroutine(_hit.collider.GetComponent<PickUp_Controller>().holdItem());
            }

            if (imgGaze.fillAmount == 1 && _hit.collider.CompareTag("Door"))
            {

                if (toOut == true)
                    changeSceneControl.toYard();
                else
                    changeSceneControl.toRoom();
            }
        }
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
    }

    IEnumerator waiter()
    {
        if (gameObject.GetComponent<Walk_Toggle>().walkToggle)
        {
            yield return new WaitForSecondsRealtime(1);
            gameObject.GetComponent<Walk_Toggle>().walkToggle = false; 
        }
    }
}