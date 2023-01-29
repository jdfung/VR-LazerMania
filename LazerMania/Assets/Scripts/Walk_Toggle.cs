using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk_Toggle : MonoBehaviour
{
    public bool walkToggle = false;
    public int WalkSpeed;

    void Update()
    {
        transform.position = transform.position + Camera.main.transform.forward * WalkSpeed * Time.deltaTime;
    }

    public void toggleWalk()
    {
        if (walkToggle)
        {
            WalkSpeed = 0;
            walkToggle = !walkToggle;
        }

        else
        {
            WalkSpeed = 2;
            walkToggle = !walkToggle;
        }
    }

}
