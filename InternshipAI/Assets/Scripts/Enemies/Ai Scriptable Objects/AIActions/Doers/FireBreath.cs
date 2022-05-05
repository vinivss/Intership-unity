using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class FireBreath : ActionNode
{
    

    protected override void OnStart()
    {

    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        agent.animator.StopPlayback();

        //ParticleSystem particleSystem = agent.FireParticle.GetComponent<ParticleSystem>();
        //particleSystem.Play();
        agent.FireParticle.SetActive(true);
        if (!isPlaying(agent.animator, "BreathAttack"))
        {
            agent.animator.Play("BreathAttack");
          
          }
        AnimatorClipInfo[] animatorClipInfos = agent.animator.GetCurrentAnimatorClipInfo(0);
        string clipName = animatorClipInfos[0].clip.name;
        Debug.Log(clipName) ;


        if (!isPlaying(agent.animator, "BreathAttack") && !isPlaying(agent.animator, "Blend Tree") || agent.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0)
        {
            Debug.Log("turn off particle");
          

            return State.SUCCESS;
        }
        return State.RUNNING;
       
    }

    bool isPlaying(Animator anim, string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(stateName) &&
                anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
         
            return true;
        }
        else
            return false;
    }
}