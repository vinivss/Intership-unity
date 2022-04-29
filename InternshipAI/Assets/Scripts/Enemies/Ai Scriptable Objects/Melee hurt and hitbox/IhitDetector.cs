using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IhitDetector 
{
   public IhitResponder hitResponder { get; set; }

    public void CheckHit();
}
