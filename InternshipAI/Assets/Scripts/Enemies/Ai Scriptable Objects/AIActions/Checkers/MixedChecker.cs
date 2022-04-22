using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;

public class MixedChecker : ActionNode
{
    protected override void OnStart()
    {

    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        if (blackboard.enemyType == "Mixed")
        {
            return State.SUCCESS;
        }
        return State.FAIL;
    }
}
