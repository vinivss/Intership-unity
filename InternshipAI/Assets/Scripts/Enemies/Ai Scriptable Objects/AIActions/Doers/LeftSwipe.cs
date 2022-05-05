using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class LeftSwipe : ActionNode
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
        agent.animator.Play("SwipeAttack");
        

        if (!agent.animator.GetCurrentAnimatorStateInfo(0).IsName("SwipeAttack"))
        {
            return State.SUCCESS;
        }

        return State.RUNNING;
    }
}
