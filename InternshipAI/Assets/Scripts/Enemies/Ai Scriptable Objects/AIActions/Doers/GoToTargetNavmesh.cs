using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class GoToTargetNavmesh : ActionNode
{
    Transform transform;
    float timer = 0.0f;
    protected override void OnStart()
    {
     
    }

    protected override void OnStop()
    {
       
    }

    protected override State OnUpdate()
    {
        transform = agent.transform;
        timer -= Time.deltaTime;
        if (timer < 0.0f)
        {
            //Debug.Log("outer Loop");
            //float sqDistance = (transform.position - agent.navMesh.destination).sqrMagnitude;
            //if (Vector3.Distance(transform.position, agent.navMesh.destination) > 0.1f)
            //{
                //Debug.Log("inner Loop");
                agent.navMesh.destination = agent.targetList[0].transform.position;


            //}
            timer = blackboard.maxTime;
        }


        //Debug.Log("Your Go To is being called");
        //transform.position = Vector3.MoveTowards(transform.position, agent.targetList[0].transform.position, agent.WalkSpeed + Time.deltaTime);
        if (agent.rangeChecker.InMelee == true)
        {
            return State.SUCCESS;
        }

        return State.RUNNING;
        


    }


   
}
