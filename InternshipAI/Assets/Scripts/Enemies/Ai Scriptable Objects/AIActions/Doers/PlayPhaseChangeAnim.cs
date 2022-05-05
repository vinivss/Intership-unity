using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class PlayPhaseChangeAnim : ActionNode
{
    protected override void OnStart()
    {
  
    }

    protected override void OnStop()
    {
       
    }

    protected override State OnUpdate()
    {
        agent.ChangeParticle.SetActive(true);
        agent.animator.Play("BreathAttack");

        blackboard.StateChanged = true;
        return State.SUCCESS;
    }
}
