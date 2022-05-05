using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class DeactivateFlames : ActionNode
{
    protected override void OnStart()
    {
       
    }

    protected override void OnStop()
    {
    
    }

    protected override State OnUpdate()
    {
        if (agent.FireParticle.activeSelf)
        {
            agent.FireParticle.SetActive(false);
        }

        return State.SUCCESS;
    }
}
