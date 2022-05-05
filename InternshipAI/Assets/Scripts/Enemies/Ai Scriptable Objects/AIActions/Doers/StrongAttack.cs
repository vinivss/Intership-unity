using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;

public class StrongAttack : ActionNode
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

        agent.animator.Play("StrongAttack");


        if (!agent.animator.GetCurrentAnimatorStateInfo(0).IsName("StrongAttack"))
        {
            return State.SUCCESS;
        }

        return State.RUNNING;
       
    }
}
