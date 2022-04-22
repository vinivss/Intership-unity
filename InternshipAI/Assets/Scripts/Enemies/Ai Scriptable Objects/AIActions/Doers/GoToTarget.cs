using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;

public class GoToTarget : ActionNode
{
    Transform transform;
    protected override void OnStart()
    {
       
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        transform = agent.transform;
        Debug.Log("Your Go To is being called");
        transform.position = Vector3.MoveTowards(transform.position, agent.targetList[0].transform.position, agent.WalkSpeed + Time.deltaTime);

        return State.RUNNING;
    }
}
