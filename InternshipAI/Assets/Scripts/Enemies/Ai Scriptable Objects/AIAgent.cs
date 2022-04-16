using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
using UnityEngine.AI;
public class AIAgent : MonoBehaviour
{
    [SerializeField] EnemyScriptableObject enemyattributes;
    //[SerializeField] NavMeshAgent navMeshAgent;

    [Header("Attributes")]
    [Tooltip("Does the AI use smart Pathfinding?")]
    [HideInInspector] public bool Smart;
    [Tooltip("How much health will the enemy have?")]
    [HideInInspector] [Min(0)] public int Health;
    [Header("Movement Attributes")]
    [Tooltip("At what speed does this enemy walk?")]
    [HideInInspector] [Min(0)] public float WalkSpeed;
    [Tooltip("How fast does this enemy run?")]
    [HideInInspector] [Min(0)] public float RunSpeed;
    [Header("Attack Attributes")]
    [Tooltip("How fast does this enemy attack?")]
    [HideInInspector] [Min(0)] public float attackRate;
    [Tooltip("How much damage does this enemy do?")]
    [HideInInspector] [Min(0)] public int damage;
    [Header("Search Attributes")]
    [Tooltip("How long will this enemy search for someone?")]
    [HideInInspector] [Min(0)] public int SearchTime;
    [Tooltip("How fast will this enemy turn while searching?")]
    [HideInInspector] [Min(0)] public int SearchTurnSpeed;

    [Tooltip("List of waypoints that teh enemy will patrol through")]
    public List<Transform> waypoints = new List<Transform>();

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    [HideInInspector]public Transform transform;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

    // Start is called before the first frame update
    void Start()
    {
        Smart = enemyattributes.Smart;
        Health = enemyattributes.Health;
        WalkSpeed = enemyattributes.WalkSpeed;
        RunSpeed = enemyattributes.RunSpeed;
        attackRate = enemyattributes.attackRate;
        damage = enemyattributes.damage;
        SearchTime = enemyattributes.SearchTime;
        SearchTurnSpeed = enemyattributes.SearchTurnSpeed;
        transform = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
