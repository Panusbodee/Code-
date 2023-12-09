using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : MonoBehaviour
{
    public GameObject itemToDrop;
    public AudioClip booSound;
    public AudioSource sourse;

    private void Start()
    {
        AudioSource.PlayClipAtPoint(booSound, transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            DropItem();
        }
    }

    public void DropItem()
    {
        if (itemToDrop != null)
        {
            Instantiate(itemToDrop, transform.position, Quaternion.identity);
        }
    }
}
