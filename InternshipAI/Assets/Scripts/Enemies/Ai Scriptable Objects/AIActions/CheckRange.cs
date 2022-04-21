using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;


public class CheckRange : ActionNode
{
    
    protected override void OnStart()
    {
        
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        
        if(agent.inSphere == true)
        {
            agent.inSphere = false;

            return State.SUCCESS;
        }

      
            return State.FAIL;
        
    }


}
