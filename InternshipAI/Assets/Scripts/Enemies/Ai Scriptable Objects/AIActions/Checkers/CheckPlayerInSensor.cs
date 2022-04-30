using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AI;
public class CheckPlayerInSensor : ActionNode
{
    
    protected override void OnStart()
    {
        
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        
        if(agent.sensor.Objects.Count > 0)
        {
            return State.SUCCESS;
        }

        return State.FAIL;
    }
}
