using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  AI;

public class Patrol : ActionNode
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
        throw new System.NotImplementedException();
    }

    protected override State OnUpdate()
    {
        transform = agent.transform;

        if (iswaiting)
        {
            waitCount += Time.deltaTime;
            if(waitCount >= agent.SearchTime)
            {
                iswaiting = false;
            }
        }
        else
        {
            Transform wp = agent.waypoints[waypointIndex];

            if (Vector3.Distance(transform.position, wp.position) < 0.01f)
            {
                transform.position = wp.position;
                waitCount = 0f;
                iswaiting = true;

                waypointIndex = (waypointIndex + 1) % agent.waypoints.Count;
            }

            else
            {
                transform.position = Vector3.MoveTowards(transform.position, wp.position, agent.WalkSpeed + Time.deltaTime);
                transform.LookAt(wp.position);
            }
        }

        state = State.RUNNING;

        return state;





    }
}
