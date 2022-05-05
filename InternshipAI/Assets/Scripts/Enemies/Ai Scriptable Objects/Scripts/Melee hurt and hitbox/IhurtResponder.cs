using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IhurtResponder 
{
    public bool CheckHit(HitData data);

    public void Response(HitData data);
}
