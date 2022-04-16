using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace AI
{
   
    [CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy AI/Enemy AI Stats ", order = 0)]
    public class EnemyScriptableObject : ScriptableObject
    {
        
        //Sprite icon;
       public enum EnemyType
      {
            Melee,
            Ranged,
            Mixed
      }
        [Header("Type of Enemy")]
        [Tooltip("What type of enemy is this AI? \n Melee: Charges the player and does a melee attack \n Ranged: Runs from the player while attacking from a distance \n Mixed: Changes what attacks it does based on its distance to the player.")]
        [SerializeField] EnemyType enemyType;
        [Tooltip("is this enemy a boss?")]
        [SerializeField] bool Boss;
    

        [Header("Attributes")]
        [Tooltip("Does the AI use smart Pathfinding?")]
        [SerializeField] public bool Smart;
        [Tooltip("How much health will the enemy have?")]
        [SerializeField][Min(0)] public int Health;
        [Header("Movement Attributes")]
        [Tooltip("At what speed does this enemy walk?")]
        [SerializeField] [Min(0)] public float WalkSpeed;
        [Tooltip("How fast does this enemy run?")]
        [SerializeField] [Min(0)] public float RunSpeed;
        [Header("Attack Attributes")]
        [Tooltip("How fast does this enemy attack?")]
        [SerializeField] [Min(0)] public float attackRate;
        [Tooltip("How much damage does this enemy do?")]
        [SerializeField] [Min(0)] public int damage;
        [Header("Search Attributes")]
        [Tooltip("How long will this enemy search for someone?")]
        [SerializeField] [Min(0)] public int SearchTime;
        [Tooltip("How fast will this enemy turn while searching?")]
        [SerializeField] [Min(0)] public  int SearchTurnSpeed;


        //private void OnValidate()
        //{
        //    if (Boss == true)
        //    {
        //        icon = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Scripts/Enemies/Enemy Logo Sprites/gobBoss.png");
        //        return;
        //    }

        //switch (EnemyType)
        //{
        //    case enemyType.Melee:
        //        icon = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Scripts/Enemies/Enemy Logo Sprites/gobMelee.png");

        //        break;
        //    case enemyType.Ranged:
        //        icon = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Scripts/Enemies/Enemy Logo Sprites/gobRanged.png");
        //        EditorGUIUtility.SetIconForObject(this, icon);
        //        break;
        //    case enemyType.Mixed:
        //        icon = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Scripts/Enemies/Enemy Logo Sprites/gobMix.png");
        //        break;
        //}
    }

    }

