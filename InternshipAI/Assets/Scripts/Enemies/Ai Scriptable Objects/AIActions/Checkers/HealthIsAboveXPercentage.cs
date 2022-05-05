using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;

public class HealthIsAboveXPercentage : ActionNode
{
    [Range(1, 99)] public float Percentage = 50;
    protected override void OnStart()
    {
       
    }

    protected override void OnStop()
    {
       
    }

    protected override State OnUpdate()
    {
        float currPercentage = Percentage / 100;
      
        if(agent.currentHealth >= (agent.HealthMax*currPercentage))
        {
            return State.SUCCESS;
        }

        return State.FAIL; 
    }
}
