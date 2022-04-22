using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class SetDead : ActionNode
{
    protected override void OnStart()
    {
        blackboard.alive = false;
    }

    protected override void OnStop()
    {
    
    }

    protected override State OnUpdate()
    {
        return State.SUCCESS;
    }
}
