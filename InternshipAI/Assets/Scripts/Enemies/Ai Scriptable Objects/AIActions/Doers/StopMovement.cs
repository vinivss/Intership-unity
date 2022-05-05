using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;

public class StopMovement : ActionNode
{
    protected override void OnStart()
    {
        
    }

    protected override void OnStop()
    {
       
    }

    protected override State OnUpdate()
    {
        agent.navMesh.ResetPath();
        return State.SUCCESS;
    }
}