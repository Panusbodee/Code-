using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotGena : MonoBehaviour
{
    public NavMeshAgent agent;
    void Start()
    {
        for (int i = 0; i < 50; i++)
        {
            Instantiate(agent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
