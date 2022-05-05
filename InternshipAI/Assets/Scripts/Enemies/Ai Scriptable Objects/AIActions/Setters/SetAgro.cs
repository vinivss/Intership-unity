using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class SetAgro : ActionNode
{
    [Tooltip("The value you want to set aggro to")]
    public bool SetValue = true;
    protected override void OnStart()
    {
       
    }

    protected override void OnStop()
    {
      
    }

    protected override State OnUpdate()
    {
        blackboard.Aggro = SetValue;
        return State.SUCCESS;
    }
}
