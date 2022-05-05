using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class CheckAggroRange : ActionNode
{
    protected override void OnStart()
    {

    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        if (agent.aggroRange.Objects.Count > 0)
        {
            
            return State.SUCCESS;
        }
        //Debug.Log($"Count Of aggro Objects{agent.aggroRange.Objects.Count}");
        return State.FAIL;
    }
}
