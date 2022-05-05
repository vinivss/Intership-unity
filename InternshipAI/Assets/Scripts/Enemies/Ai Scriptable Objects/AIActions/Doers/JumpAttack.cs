using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class JumpAttack : ActionNode
{
    protected override void OnStart()
    {
        
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        if (!isPlaying(agent.animator, "BreathAttack"))
            agent.animator.Play("JumpAttack");
        if (!isPlaying(agent.animator, "BreathAttack"))
        {

            
            return State.SUCCESS;
        }
       

        return State.RUNNING;
    }

    bool isPlaying(Animator anim, string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(stateName) &&
                anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {

            return true;
        }
        else
            return false;
    }
}
