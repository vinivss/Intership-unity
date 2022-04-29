using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class MeleeJab : ActionNode
{
    protected override void OnStart()
    {
        Debug.Log("Starting the Jab");
    }

    protected override void OnStop()
    {
      
    }

    protected override State OnUpdate()
    {
        agent.animator.Play("Jab");


        return State.SUCCESS;
    }
}
