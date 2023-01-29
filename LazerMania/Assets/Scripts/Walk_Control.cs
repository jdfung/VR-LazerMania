using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk_Control : MonoBehaviour
{
    private int WalkSpeed;

    [SerializeField] GameObject player;

    // Update is called once per frame
    void Update()
    {
        player.transform.position = player.transform.position + Camera.main.transform.forward * WalkSpeed * Time.deltaTime;
    }

    public bool move()
    {
        WalkSpeed = 2;
        return true;
    }

    public bool stop()
    {
        WalkSpeed = 0;
        return false;
    }

    public void pause()
    {
        WalkSpeed = 0;
    }

    public void conti()
    {
        WalkSpeed = 2;
    }
}
