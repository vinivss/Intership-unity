using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitData 
{
    public int damage;
    public Vector3 hitPoint;
    public Vector3 hitNormal;
    public IHurtbox hurtbox;
    public IhitDetector hitDetector;

    public bool Validate()
    {
        if(hurtbox != null)
        {
            if(hurtbox.CheckHit(this))
            {
                if(hurtbox.hurtResponder == null || hurtbox.hurtResponder.CheckHit(this))
                {
                    if(hitDetector.hitResponder == null || hitDetector.hitResponder.CheckHit(this))
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }
}
