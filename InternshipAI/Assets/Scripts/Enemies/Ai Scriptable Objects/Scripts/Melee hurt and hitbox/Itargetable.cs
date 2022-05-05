using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Itargetable 
{
  public bool Targetable { get; }

    public Transform TargetTransform { get; }
}
