using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastGun : MonoBehaviour
{
    public Camera playerCamera;
    public Transform laserOrigin;
    public float gunRange = 50f;
    public float fireRate = 0.2f;
    public float laserDuration = 0.05f;
    private RaycastHit hit;
    LineRenderer laserLine;
    float fireTimer;

    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    void Update()
    {
        fireTimer += Time.deltaTime;
        Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(1f, 1f, 0));
        if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunRange))
        {
            //Debug.Log(hit.transform.tag);
            if (hit.transform.CompareTag("Enemy") && fireTimer > fireRate)
            {
                fireTimer = 0;
                laserLine.SetPosition(0, laserOrigin.position);
                
                if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunRange))
                {
                    laserLine.SetPosition(1, hit.point);
                    StartCoroutine(waiter(hit));
                }
                else
                {
                    laserLine.SetPosition(1, rayOrigin + (playerCamera.transform.forward * gunRange));
                }
                StartCoroutine(ShootLaser());
            }
        }
    }

    IEnumerator ShootLaser()
    {
        laserLine.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        laserLine.enabled = false;

    }


    IEnumerator waiter(RaycastHit hit)
    {
        hit.transform.gameObject.SetActive(false);
        //Wait for 2 seconds
        yield return new WaitForSecondsRealtime(2);
        hit.transform.gameObject.SetActive(true);

    }
}
