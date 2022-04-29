using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class RepeatXtimes : DecoratorNode
{
    public int x;

    protected override void OnStart()
    {
      
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        int y = 0;
        if(y==x)
        {
            return State.SUCCESS;
        }

        y++;
        return State.RUNNING;
    }
}
