using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;

//this script will get data and information needed for the behaviour tree and pass it around. consider using the scriptable objects to get said data


[System.Serializable]
public class BlackBoard
{
    public float maxDistance = 1.0f;
    public float maxTime = 1.0f;
    public bool alive = true;
    public string enemyType;
    public bool Aggro = false;
}
