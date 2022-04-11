using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
    // iterates over the children from start to finish. and if one of the children fails then the whole node fails.
 
    public class SequencerNode : CompositeNode
    {
        int curr;
        protected override void OnStart()
        {
            curr = 0;
        }

        protected override void OnStop()
        {
           
        }

        protected override State OnUpdate()
        {
           var child = Children[curr];

            //keep running until either the state Fails or all children return success
            switch(child.Update())
            {
                case State.RUNNING:
                    return State.RUNNING;
                case State.FAIL:
                    return State.FAIL;
                case State.SUCCESS:
                    curr++;
                    break;
            }
            // if current is equal to the total number of children then return success else keep running

            return curr == Children.Count ? State.SUCCESS : State.RUNNING;
        }
    }

