using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class SetAISize : ActionNode
{
    [Min(0.1f)]public float Multiplier = 0.1f;
    protected override void OnStart()
    {
  
    }

    protected override void OnStop()
    {
    
    }

    protected override State OnUpdate()
    {
        Vector3 local = agent.gameObject.transform.localScale;
        agent.gameObject.transform.localScale = new Vector3(local.x * Multiplier, local.y * Multiplier, local.z * Multiplier);
        return State.SUCCESS;
    }
}
