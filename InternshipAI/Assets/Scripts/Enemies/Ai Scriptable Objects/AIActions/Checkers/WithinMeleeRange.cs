using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class WithinMeleeRange : ActionNode
{
    public bool inRange;
  
    protected override void OnStart()
    {
        
    }

    protected override void OnStop()
    {
      
    }

    protected override State OnUpdate()
    {
        MeleeRangeChecker rangeChecker= agent.rangeChecker;  
        inRange = rangeChecker.InMelee;
        Debug.Log(rangeChecker.InMelee);
        if (inRange == true)
        {
            Debug.Log("BURUSHITTO BUREJING");

            return State.SUCCESS;
        }

        return State.FAIL;
    }
}
