using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompHurtbox : MonoBehaviour, IHurtbox
{
    [SerializeField] bool m_active = true;
    [SerializeField] GameObject owner = null;

    IhurtResponder m_hurtResponder;
    public bool active { get => m_active; }

    public GameObject Owner { get => owner; }

    public Transform Transform { get => transform; }

    public IhurtResponder hurtResponder { get => m_hurtResponder; set => m_hurtResponder = value; }

    public bool CheckHit(HitData hitdata)
    {
        if(m_hurtResponder == null)
        {
            Debug.Log("No Responder");
        }
        return true;
    }
}
