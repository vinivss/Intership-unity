using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
using UnityEngine.AI;
public class AIAgent : MonoBehaviour
{
    [SerializeField] EnemyScriptableObject enemyattributes;

    [HideInInspector] public string enemyType;
    //Variables hidden in inspector
    [HideInInspector] public bool Smart;
    [HideInInspector] [Min(0)] public float HealthMax;
    [HideInInspector] [Min(0)] public float WalkSpeed;
    [HideInInspector] [Min(0)] public float RunSpeed;
    [HideInInspector] [Min(0)] public float attackRate;
    [HideInInspector] [Min(0)] public int damage;
    [HideInInspector] [Min(0)] public int SearchTime;
    [HideInInspector] [Min(0)] public int SearchTurnSpeed;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    [HideInInspector] public Transform transform;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    [HideInInspector] public bool inSphere;
    [HideInInspector] public MeleeRangeChecker rangeChecker;
    // this little variable will just add be a target for the AI.
    [HideInInspector] public List<GameObject> targetList = new List<GameObject>();
    [HideInInspector] public Animator animator;
    [HideInInspector] public Rigidbody[] rigidbodies;

    //public variables
    public List<Transform> waypoints = new List<Transform>();
    [Tooltip("Navmesh for the AiAgent")]
    public NavMeshAgent navMesh;
    [Tooltip("Current Health of the AI")]
    public float currentHealth;

    //private variables
    GameObject thisGameObject;
    [Tooltip("Range Check bounds for Melee")]
    



  
    // Start is called before the first frame update
    void Start()
    {
        GetTypeOfAI();
        rangeChecker = GetComponentInChildren<MeleeRangeChecker>();
        Smart = enemyattributes.Smart;
        HealthMax= enemyattributes.HealthMax;
        WalkSpeed = enemyattributes.WalkSpeed;
        RunSpeed = enemyattributes.RunSpeed;
        attackRate = enemyattributes.attackRate;
        damage = enemyattributes.damage;
        SearchTime = enemyattributes.SearchTime;
        SearchTurnSpeed = enemyattributes.SearchTurnSpeed;
        transform = gameObject.transform;
        thisGameObject = gameObject;
        navMesh = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        currentHealth = HealthMax;
        
        //make sure that on start all ragdolls are deactivated
        StartRigidbodies();
        foreach(var rigidBody in rigidbodies)
        {
            rigidBody.gameObject.AddComponent<HitBox>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", navMesh.velocity.magnitude);
        transform = gameObject.transform;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            inSphere = true;
           
            targetList.Add(other.gameObject);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inSphere = false;
        }

     }
    public void GetTypeOfAI()
    {
        switch(enemyattributes.enemyType)
        {
            case EnemyScriptableObject.EnemyType.Melee:
                enemyType = "Melee";
                break;
            case EnemyScriptableObject.EnemyType.Ranged:
                enemyType = "Ranged";
                break;
            case EnemyScriptableObject.EnemyType.Mixed:
                enemyType = "Mixed";
                break;
        }
    }    
    public void StartRigidbodies()
    {
       foreach(var rigidBody in rigidbodies)
        {
            rigidBody.isKinematic = true;
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

    }

}
