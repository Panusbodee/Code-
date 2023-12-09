using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Droppable : MonoBehaviour
{
    [SerializeField] private UnityEvent onDrop = null;
    public void Drop()
    {
        gameObject.SetActive(true);
        transform.parent = null;

        onDrop?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
