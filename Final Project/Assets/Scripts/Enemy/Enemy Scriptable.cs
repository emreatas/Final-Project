using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "EnemyScriptable")]
public class EnemyScriptable : ScriptableObject
{
    public float range, sightRange;
    public int health;
    public float attackRate;
    public float patrolRadius;
}