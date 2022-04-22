using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class SetHealthToMax : ActionNode
{
    protected override void OnStart()
    {
        agent.currentHealth = agent.HealthMax;

        Debug.Log($"Set health to max Health {agent.HealthMax}");
    }

    protected override void OnStop()
    {
      
    }

    protected override State OnUpdate()
    {
        return State.SUCCESS;
    }
}
