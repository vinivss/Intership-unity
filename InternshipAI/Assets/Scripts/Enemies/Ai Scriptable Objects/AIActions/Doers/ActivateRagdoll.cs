using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class ActivateRagdoll : ActionNode
{
    protected override void OnStart()
    {
        foreach (var rigidBody in agent.rigidbodies)
        {
            rigidBody.isKinematic = true;

        }
        agent.animator.enabled = false;
        Debug.Log("Ragdoll Activated");
    }

    protected override void OnStop()
    {
      
    }

    protected override State OnUpdate()
    {
        
        return State.SUCCESS;
    }
}
