using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    public AudioClip item_sfx;
    public AudioSource sourse;


    void Start()
    {

    }


    void pickUpItem()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sourse.PlayOneShot(item_sfx);
        }

    }

    void Update()
    {
        pickUpItem();
    }
}
