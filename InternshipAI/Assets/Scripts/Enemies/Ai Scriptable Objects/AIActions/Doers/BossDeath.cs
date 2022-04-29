using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class BossDeath : ActionNode
{
    // Start is called before the first frame update
    protected override void OnStart()
    {
        
    }

    protected override void OnStop()
    {
       
    }

    protected override State OnUpdate()
    {
        agent.animator.Play("Death");

        return State.SUCCESS;
    }
}
