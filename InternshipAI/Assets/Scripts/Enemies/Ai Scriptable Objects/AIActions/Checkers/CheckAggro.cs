using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class CheckAggro : ActionNode
{
    protected override void OnStart()
    {
        
    }

    protected override void OnStop()
    {
       
    }

    protected override State OnUpdate()
    {
        if(blackboard.Aggro == true)
        {
            return State.SUCCESS;
        }

        return State.FAIL;
    }
}
