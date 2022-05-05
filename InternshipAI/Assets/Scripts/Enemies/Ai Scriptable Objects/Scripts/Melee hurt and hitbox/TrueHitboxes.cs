using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TrueHitboxes : MonoBehaviour
{
    public LayerMask HitboxLayer;
    public bool useSphere = false;
    public float radius = 0.5f;
    public Vector3 boxSizes = Vector3.one;

    public Color inactiveColor;

    public Color collisionOpenColor;

    public Color collidingColor;

    public enum ColliderState
    {
        Closed,
        Open,
        Colliding
    }

    private ColliderState _state;
    public void Update()
    {
        if(_state == ColliderState.Closed)
        {
            return;
        }
        CollisionMeasure();
    }
    private void CollisionMeasure()
    {
        Collider[] colliders = Physics.OverlapBox(gameObject.transform.position, boxSizes, transform.rotation, HitboxLayer);
        if (colliders.Length > 0)
        {
            Debug.Log("We hit something");
            _state = ColliderState.Colliding;
        }
        else
        {
            _state = ColliderState.Open;
        }
    }

    private void OnDrawGizmos()
    {
        checkGizmoColor();
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);
        Gizmos.DrawCube(Vector3.zero, new Vector3(boxSizes.x * 2, boxSizes.y * 2, boxSizes.z * 2));
    }

    private void checkGizmoColor()
    {
        switch(_state)
        {
            case ColliderState.Closed:
                Gizmos.color = inactiveColor;
                break;
            case ColliderState.Open:
                Gizmos.color = collisionOpenColor;
                break;
            case ColliderState.Colliding:
                Gizmos.color = collidingColor;
                break;
        }
    }

    public void startCheckingCollision()
    {
        _state = ColliderState.Open;

    }

    public void stopCheckingCollision()
    {
        _state = ColliderState.Closed;

    }
}
