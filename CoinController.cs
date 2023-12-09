using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public float spinSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(0,spinSpeed, 0));
    }
}
