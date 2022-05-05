using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;

public class SetStateChanged : ActionNode
{
    public bool SetStateChange = false;
    protected override void OnStart()
    {
      
    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        blackboard.StateChanged = true;
        return State.SUCCESS;
    }
}
