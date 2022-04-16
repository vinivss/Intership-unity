using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;


public class SelectorNode : CompositeNode
{
    
    int curr;
   
    protected override void OnStart()
    {
        curr = 0;
       
    }

    protected override void OnStop()
    {
        throw new System.NotImplementedException();
    }

    protected override State OnUpdate()
    {
        var child = Children[curr];
      
        switch (child.Update())
        {
            case State.RUNNING:
                
                return State.RUNNING;
                  
            case State.FAIL:
                break;
            case State.SUCCESS:
                return State.SUCCESS;

        }

         return curr == Children.Count ? State.FAIL : State.RUNNING;
    }


}
