using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class GoToTargetNavmesh : ActionNode
{
    Transform transform;
    float timer = 0.0f;
 
    GameObject target;

    bool HasStoped;
    protected override void OnStart()
    {
        HasStoped = false;
    }

    protected override void OnStop()
    {
       
    }

    protected override State OnUpdate()
    {
        transform = agent.transform;
        timer -= Time.deltaTime;
        if(agent.sensor.Objects.Count > 0 )
        target = agent.sensor.Objects[0].gameObject;

        if (timer <= 0.0f)
        {
            //Debug.Log("outer Loop");
            //float sqDistance = (transform.position - agent.navMesh.destination).sqrMagnitude;
            //if (Vector3.Distance(transform.position, agent.navMesh.destination) > 0.1f)
            //{
            //Debug.Log("inner Loop");
            
                
            agent.navMesh.SetDestination(target.transform.position);

            //if(agent.navMesh.destination != null)
            //{
            //    Debug.Log(agent.navMesh.destination);
            //}

            //}
            timer = blackboard.maxTime;
        }


        //Debug.Log("Your Go To is being called");
        //transform.position = Vector3.MoveTowards(transform.position, agent.targetList[0].transform.position, agent.WalkSpeed + Time.deltaTime);
        agent.navMesh.SetDestination(target.transform.position);
        if (Vector3.Distance(agent.transform.position, agent.navMesh.destination) < 1.0f )
        {
            HasStoped = true;
            timer = blackboard.maxTime;
            Debug.Log("In");
            agent.navMesh.ResetPath();
            agent.animator.SetFloat("Speed", 0);
            return State.SUCCESS;
        }

        return State.SUCCESS;
        


    }


   
}
