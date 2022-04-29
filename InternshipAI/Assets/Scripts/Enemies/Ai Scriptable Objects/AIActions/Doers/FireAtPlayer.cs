using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class FireAtPlayer : ActionNode
{
    protected override void OnStart()
    {
        
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        agent.animator.Play("Fireball");

        return State.SUCCESS;
    }
}
