using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasterController : MonoBehaviour
{
    public float shootingRange = 5.0f;
    Ray ray;
    RaycastHit hitData;
    void Start()
    {
        ray = new Ray(transform.position, transform.forward);
        //transform.up = new Vector3(0, 1, 0);
        //transform.right = new Vector3(1, 0, 0);

    }

    
    void Update()
    {
        ray.origin = transform.position;
        ray.direction = transform.forward;
        Debug.DrawRay(ray.origin, ray.direction * shootingRange, Color.cyan);

        if (Physics.Raycast(ray,out hitData, shootingRange))
        {
            Debug.Log("Hit : " + hitData.transform.gameObject.tag );

            if (hitData.transform.gameObject.CompareTag("item"))
            {
                Destroy(hitData.transform.gameObject);
                Debug.DrawRay(ray.origin, ray.direction * shootingRange, Color.yellow);
            }
        }
    }
}
