using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using AI;

public class DebugNavMeshAgent : MonoBehaviour
{
    public bool velocity;
    public bool desiredVelocity;
    public bool path;

    public bool Destination;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
       
    }

    // Update is called once per frame
    private void OnDrawGizmos()
    {
        if(velocity)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + agent.velocity);

        }

        if (desiredVelocity)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, transform.position + agent.desiredVelocity);

        }

        if (path)
        {
            Gizmos.color = Color.blue;
          
            
                var agentPath = agent.path;
            
            Vector3 prevCorner = transform.position;
            foreach(var corner in agentPath.corners)
            {
                Gizmos.DrawLine(prevCorner, corner);
                Gizmos.DrawSphere(corner, 0.1f);

                prevCorner = corner;
            }
        }

        if(Destination)
        {
            Gizmos.color = Color.magenta;

            Gizmos.DrawSphere(agent.destination, 0.5f);
        }


    }
}
