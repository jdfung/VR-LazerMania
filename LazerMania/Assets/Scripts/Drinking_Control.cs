using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drinking_Control : MonoBehaviour
{
    private GameObject targetCup;
    
    [SerializeField] private GameObject cup;
    [SerializeField] private AudioSource sfx;

    public void drink(GameObject targetDrink)
    {
        targetCup = targetDrink;

        targetCup.SetActive(false);
        cup.SetActive(true);
        sfx.Play();

        StartCoroutine(drinking());
    }

    IEnumerator drinking()
    {
        yield return new WaitForSecondsRealtime(3);

        cup.SetActive(false);
        targetCup.SetActive(true);
    }

}
