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
        agent.transform.LookAt(agent.targetList[0].transform);

        return State.SUCCESS;
    }
}

