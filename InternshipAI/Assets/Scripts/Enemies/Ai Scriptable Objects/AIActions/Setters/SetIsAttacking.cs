using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class SetIsAttacking : ActionNode
{
    public bool SetAs = false;
    protected override void OnStart()
    {
        
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        blackboard.isAtttacking = SetAs;
        return State.SUCCESS;
    }
}
