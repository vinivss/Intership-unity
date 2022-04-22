using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class RepeatIfAlive : DecoratorNode
{
    protected override void OnStart()
    {
       
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        if(blackboard.alive == false)
        {
            return State.SUCCESS;
        }

        child.Update();
        return State.RUNNING;
    }
}
