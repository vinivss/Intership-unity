using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompHitbox : MonoBehaviour, IhitDetector
{
    [SerializeField] BoxCollider mcollider;
    [SerializeField] LayerMask layerMask;

    private float Thickness = 0.025f;
    private IhitResponder mhitResponder;
    public IhitResponder hitResponder { get => mhitResponder; set => mhitResponder = value; }

    public void CheckHit()
    {
        Vector3 scaledSize = new Vector3(mcollider.size.x * transform.lossyScale.x, mcollider.size.y * transform.lossyScale.y, mcollider.size.z * transform.lossyScale.z);

        float distance = scaledSize.y - Thickness;
        Vector3 direction = transform.up;
        Vector3 center = transform.TransformPoint(mcollider.center);
        Vector3 start = center - direction * (distance / 2);
        Vector3 halfExtents = new Vector3(scaledSize.x, Thickness, scaledSize.z);
        Quaternion orientation = transform.rotation;

        HitData hitData = null;
        IHurtbox _hurtbox = null;
        RaycastHit[] hits = Physics.BoxCastAll(start, halfExtents, direction, orientation, distance, layerMask);

        foreach(RaycastHit hit in hits)
        {
            _hurtbox = hit.collider.GetComponent<IHurtbox>();
            if(_hurtbox != null)
            {
                if (_hurtbox.active)
                {
                    //generate hitdata
                    hitData = new HitData
                    {
                        damage = hitResponder == null ? 0 : hitResponder.damage,
                        hitPoint = hit.point == Vector3.zero ? center : hit.point,
                        hitNormal = hit.normal,
                        hurtbox = _hurtbox,
                        hitDetector = this
                    };

                    if(hitData.Validate())
                    {
                        hitData.hitDetector.hitResponder?.Response(hitData);
                        hitData.hurtbox.hurtResponder?.Response(hitData);
                    }
                }
            }

        }
    }
}
