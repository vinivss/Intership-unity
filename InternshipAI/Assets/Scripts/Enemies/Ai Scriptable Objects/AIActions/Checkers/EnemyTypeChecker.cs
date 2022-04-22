using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class EnemyTypeChecker : ActionNode
{
    protected override void OnStart()
    {
       
    }

    protected override void OnStop()
    {
       
    }

    protected override State OnUpdate()
    {
        if(agent.enemyType == "Melee")
        {
            blackboard.enemyType = "Melee";
            return State.SUCCESS;
        }
        else if(agent.enemyType == "Ranged")
        {
            blackboard.enemyType = "Ranged";
            return State.SUCCESS;
        }
        else if (agent.enemyType == "Mixed")
        {
            blackboard.enemyType = "Mixed";
            return State.SUCCESS;
        }
        return State.FAIL;
    }
}
