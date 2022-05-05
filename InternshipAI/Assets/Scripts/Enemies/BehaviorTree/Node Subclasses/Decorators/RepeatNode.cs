using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AI;
    // you can customize this Node so that it can run a cerrtain amount of time. making for and while loops possible.
    public class RepeatNode : DecoratorNode
    {
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            child.Update();
            return State.RUNNING;
        }
    }
