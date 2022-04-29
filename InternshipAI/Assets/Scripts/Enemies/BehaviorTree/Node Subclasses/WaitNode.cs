using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    //creates a delay in the treee execution
    public class WaitNode : ActionNode
    {
        public float waitTime = 3;
        float startTime;

        protected override void OnStart()
        {
            //setting the time of start to the time at which the start occurs
            startTime = Time.time;
          
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            if((Time.time - startTime) > waitTime)
            {
             
                return State.SUCCESS;
            }
            return State.RUNNING;
        }
    }
}
