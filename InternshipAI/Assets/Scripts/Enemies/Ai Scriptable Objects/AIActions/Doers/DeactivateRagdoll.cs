using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class DeactivateRagdoll : ActionNode
{
    protected override void OnStart()
    {
        foreach (var rigidBody in agent.rigidbodies)
        {
            rigidBody.isKinematic = false;
        }
        agent.animator.enabled = true;
        Debug.Log("Ragdoll Deactivated");
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
      
        return State.SUCCESS;
    }
}
