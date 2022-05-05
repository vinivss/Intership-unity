using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtbox : MonoBehaviour, Itargetable, IhurtResponder
{
    [SerializeField] private bool m_targetable = true;
    [SerializeField] private Transform targetTransform;
    [SerializeField] private Rigidbody m_rbBag;
    private List<CompHurtbox> m_hurtboxes = new List<CompHurtbox>();
    bool Itargetable.Targetable { get => m_targetable; }

    Transform Itargetable.TargetTransform { get => targetTransform; }

    private void Start()
    {
        m_hurtboxes = new List<CompHurtbox>(GetComponentsInChildren<CompHurtbox>());
        foreach(CompHurtbox _hurtbox in m_hurtboxes)
        {
            _hurtbox.hurtResponder = this; 

        }
    }
    bool IhurtResponder.CheckHit(HitData data)
    {
        return true;
    }

    void IhurtResponder.Response(HitData data)
    {
        Debug.Log("worked");
    }
}
