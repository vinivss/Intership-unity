using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class SetAgro : ActionNode
{
    protected override void OnStart()
    {
       
    }

    protected override void OnStop()
    {
      
    }

    protected override State OnUpdate()
    {
        blackboard.Aggro = true;
        return State.SUCCESS;
    }
}
