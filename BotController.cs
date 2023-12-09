using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotController : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject[] destinations;
    Ray ray;
    RaycastHit hitData;
    public bool specail = false;
    public Material color1;
    public Material color2;
    
    public int deadTime = 40;
    private bool isDead = false;

    void Start()
    {
        

        destinations = GameObject.FindGameObjectsWithTag("des");
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(destinations[Random.Range(0, destinations.Length)].transform.position);

        ray = new Ray(transform.position, transform.forward);
    }

    IEnumerator WaitingToDie()
    {
        Debug.Log("Dead Time : " + Time.time);
        yield return new WaitForSeconds(deadTime);
        isDead = true;
        this.gameObject.GetComponent<Renderer>().material = color1;
        agent.isStopped = true; 
    }

    // Update is called once per frame
    void Update()
    {
        ray.origin = transform.position;
        ray.direction = transform.forward;
        if (agent.remainingDistance < 0.5)
        {
            agent.SetDestination(destinations[Random.Range(0, destinations.Length)].transform.position);
        }

        if (Physics.Raycast(ray, out hitData, 10.0f))
        {
            Debug.DrawRay(ray.origin, ray.direction * hitData.distance, Color.blue);
            //Debug.Log("Hit : " + hitData.transform.gameObject.name);

            if (hitData.collider.gameObject.CompareTag("Woof"))
            {
                if (specail)
                {
                    hitData.collider.gameObject.GetComponent<BotController>().specail = true;
                }
            }

        }

        if (specail && !isDead)
        {
            // change color
            this.gameObject.GetComponent<Renderer>().material = color2;
            
            StartCoroutine(WaitingToDie());
        }
    }
}
