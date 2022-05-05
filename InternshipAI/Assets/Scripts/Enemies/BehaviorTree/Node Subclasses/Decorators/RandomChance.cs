using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class RandomChance : DecoratorNode
{
    public float PassRange = 1.0f;
    protected override void OnStart()
    {
      
    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        float RandomFloat = Random.Range(0.0f, 1.0f);

        if(RandomFloat <= PassRange)
        {
            //Debug.Log($"Gonna update {child.name}");
            child.Update();
            return child.state;
        }
        //Debug.Log($"Not Gonna update {child.name}");
        return State.FAIL;
    }
}
