using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject Target;
    public float MinModifier = 2;
    public float MaxModifier = 5;

    private Vector3 _velocity = Vector3.zero;
    private bool _isFollowing = false;

    void Start()
    {

    }

    public void StartFollowing()
    {
        _isFollowing = true;
    }

    void Update()
    {
        if (_isFollowing)
        {
            transform.position = Vector3.SmoothDamp(transform.position, Target.transform.position, ref _velocity, Time.deltaTime * Random.Range(MinModifier, MaxModifier));
        }
    }
}
