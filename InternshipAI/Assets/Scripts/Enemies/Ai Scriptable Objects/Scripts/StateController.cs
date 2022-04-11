using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace AI
{

    public class StateController : MonoBehaviour
    {
        public EnemyScriptableObject enemyStats;

        [HideInInspector] public NavMeshAgent agent;
        //[HideInInspector] public Shoot agent;
        [HideInInspector] public List<Transform> waypoint;
        [HideInInspector] public int nextWaypoint;
        [HideInInspector] public Transform target;
        [HideInInspector] public Vector3 LastKnownTargetPosition;

        private bool _isActive;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();

        }

        public void InitializeAI(bool activate, List<Transform> waypointList)
        {
            waypoint = waypointList;
            _isActive = activate;
            agent.enabled = _isActive;
        }
    }
}
