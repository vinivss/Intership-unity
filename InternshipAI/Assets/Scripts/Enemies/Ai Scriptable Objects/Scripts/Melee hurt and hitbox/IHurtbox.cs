using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHurtbox 
{
    public bool active { get; }

    public GameObject Owner { get; }

    public Transform Transform { get; }

    public IhurtResponder hurtResponder { get; set; }

    public bool CheckHit(HitData hitdata);
}
