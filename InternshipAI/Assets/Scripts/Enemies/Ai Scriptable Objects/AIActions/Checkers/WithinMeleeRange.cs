using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class WithinMeleeRange : ActionNode
{
    protected override void OnStart()
    {
        
    }

    protected override void OnStop()
    {
      
    }

    protected override State OnUpdate()
    {
        if (agent.rangeChecker.InMelee == true)
        {
            return State.SUCCESS;
        }

        return State.FAIL;
    }
}
