using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class LookAtPlayer : ActionNode
{
    protected override void OnStart()
    {
        
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        Transform playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        agent.transform.LookAt(playerPos);

        return State.SUCCESS;
    }
}

