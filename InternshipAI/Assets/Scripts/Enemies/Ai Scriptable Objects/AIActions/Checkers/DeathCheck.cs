using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class DeathCheck : ActionNode
{
    protected override void OnStart()
    {
      
    }

    protected override void OnStop()
    {
       
    }

    protected override State OnUpdate()
    {
        if(agent.currentHealth <= 0.0f || blackboard.alive == false)
        {
            return State.SUCCESS;
        }
        return State.FAIL;
    }
}
