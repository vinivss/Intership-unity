using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class HealthCheck : ActionNode
{
    [Tooltip("% of health that you want to be checked for")]
    public int PercentageCheck;

    float HpCheck;
    protected override void OnStart()
    {
        HpCheck = (agent.currentHealth * (PercentageCheck * 0.01f));
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        if(agent.currentHealth == HpCheck)
        {
            return State.SUCCESS;
        }

        return State.FAIL;
    }
}
