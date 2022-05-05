using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class RunAwayfromPlayer : ActionNode
{
    public float RunAwayDist = 10.0f;
    protected override void OnStart()
    {
       
    }

    protected override void OnStop()
    {
       
    }

    protected override State OnUpdate()
    {
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        float dist = Vector3.Distance(agent.transform.position, playerPos);

        Debug.Log(dist);
        Debug.Log(RunAwayDist);
        Debug.Log(dist < RunAwayDist); 

        if (dist < RunAwayDist)
        {
            Debug.Log("Run away");
            Vector3 dirToPlayer = agent.transform.position - playerPos;

            Vector3 newPos = agent.transform.position + dirToPlayer;
            agent.navMesh.SetDestination(newPos);

        }

        else if (dist >= RunAwayDist )
        {
            Debug.Log("Ran away");
            return State.SUCCESS;
        }

        return State.RUNNING;
    }
}
