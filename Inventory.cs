using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Stuff bagpack = new Stuff();
    void Start()
    {
        Debug.Log("Bullets : " + bagpack.bullets);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
