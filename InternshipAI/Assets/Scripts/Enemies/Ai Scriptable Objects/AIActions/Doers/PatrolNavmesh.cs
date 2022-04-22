using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;

public class PatrolNavmesh : ActionNode
{
    private Transform transform;
    //private List<Vector3> waypoints = new List<Vector3>();
    int waypointIndex = 0;

    float waitCount = 0;
    bool iswaiting = false;
   

  

   

    protected override void OnStart()
    {

    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        //Debug.Log($"Blackboard Max Distance{blackboard.maxDistance}");
        //Debug.Log($"Blackboard Max Time{blackboard.maxTime}");
        transform = agent.transform;

        if (iswaiting)
        {
            waitCount += Time.deltaTime;
            if (waitCount >= agent.SearchTime)
            {
                iswaiting = false;
            }
        }
        else
        {
            Transform wp = agent.waypoints[waypointIndex];


            if (Vector3.Distance(transform.position, wp.position) < 0.1f )
            {
                transform.position = wp.position;
                waitCount = 0f;
                iswaiting = true;
             
                //agent.navMesh.destination = wp.position;
                waypointIndex++;
            }

            else
            {
               agent.navMesh.destination = wp.position;
               
            }
        }
        if (waypointIndex == agent.waypoints.Count)
        {
            waypointIndex = 0;
            state = State.SUCCESS;
            return state;
        }
        state = State.SUCCESS;
        return state;


    }
}
