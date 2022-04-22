using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class MeleeChecker : ActionNode
{
    protected override void OnStart()
    {

    }

    protected override void OnStop()
    {
      
    }

    protected override State OnUpdate()
    {
       if(blackboard.enemyType == "Melee")
        {
            return State.SUCCESS;
        }
        return State.FAIL;
    }
}
