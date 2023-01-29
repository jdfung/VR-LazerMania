using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_Controller : MonoBehaviour
{
    public Transform currItem;
    public Vector3 currItemOri;
    public Transform holdArea;
    public AudioSource eatSound;
    public AudioSource drinkSound;

    public float sSpeed = 10.0f;
    public Vector3 dist;
    public bool isFood = false;

    // Start is called before the first frame update
    void Start()
    {
        currItemOri = currItem.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playAudio()
    {

    }

    public IEnumerator holdItem()
    {
        currItem.transform.position = holdArea.transform.position;
        yield return new WaitForSeconds(2);
        if (isFood)
        {
            eatSound.Play();
        }
        else
        {
            drinkSound.Play();
        }
        currItem.gameObject.SetActive(false);
        currItem.transform.position = currItemOri;
        yield return new WaitForSeconds(2);
        currItem.gameObject.SetActive(true);
    }
}
