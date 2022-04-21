using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class GoToTargetNavmesh : ActionNode
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
        //transform.position = Vector3.MoveTowards(transform.position, agent.targetList[0].transform.position, agent.WalkSpeed + Time.deltaTime);
        agent.navMesh.destination = agent.targetList[0].transform.position;
        return State.RUNNING;
    }


   
}
