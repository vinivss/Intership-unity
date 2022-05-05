using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class CheckIsAttacking : ActionNode
{
    protected override void OnStart()
    {
        
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        if(blackboard.isAtttacking == true)
        {
            return State.SUCCESS;
        }

        return State.FAIL;
    }
}
