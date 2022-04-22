using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class IfFalse : DecoratorNode
{
    protected override void OnStart()
    {
        
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        child.Update();
        if(child.state == State.FAIL)
        {
            return State.SUCCESS;
        }

        return State.FAIL;
    }
}
