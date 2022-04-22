using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;

public class IfTrue : DecoratorNode
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
        if (child.state == State.SUCCESS)
        {
            return State.SUCCESS;
        }

        return State.FAIL;
    }
}
