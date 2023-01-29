using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_Scene_Control : MonoBehaviour
{
    [SerializeField] private GameObject waypoints;
    [SerializeField] private float speed = 2f;

    [SerializeField] private AudioSource sfx;

    [SerializeField] private bool interact = false;
    [SerializeField] private bool changeToYard = false;
    [SerializeField] private bool changeToRoom = false;

    // Update is called once per frame
    void Update()
    {
        if(interact == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints.transform.position, Time.deltaTime * speed);

            if (Vector3.Distance(waypoints.transform.position, transform.position) < .001f)
            {
                if(changeToYard == true && changeToRoom == false)
                {
                    //interact = false;
                    //changeToYard = false;
                    SceneManager.LoadScene(1);
                }

                if(changeToRoom = true && changeToYard == false)
                {
                    //interact = false;
                   // changeToRoom = false;

                    SceneManager.LoadScene(0);
                }
            }
        }
    }

    public void toYard()
    {
        interact = true;
        changeToYard = true;
        sfx.Play();
    }

    public void toRoom()
    {
        interact = true;
        changeToRoom = true;
        sfx.Play();
    }
}
