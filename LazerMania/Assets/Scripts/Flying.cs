using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    public GameObject head;
    public float flyingSpeed = 0.2f;
    public bool isFlying = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FlyIfFlying();
    }

    private void FlyIfFlying()
    {
        if (isFlying)
        {
            Vector3 flyDirection = Camera.main.transform.forward;
            transform.position += flyDirection.normalized * flyingSpeed;
        }
    }
}
