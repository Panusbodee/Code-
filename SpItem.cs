using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpItem : MonoBehaviour
{
    public float spinSpeed = 1f;
    void Start()
    {
        this.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(0, spinSpeed, 0));
    }
}
