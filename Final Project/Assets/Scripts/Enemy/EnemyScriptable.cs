using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData" , menuName = "EnemyScriptable")]
public class EnemyScriptable : ScriptableObject
{
    public float sightRange, attackRange, patrolRadius, attackRate, health, damage, positionDiffWithPrefab, waitInPatrolling, exclamationRange, exp;
}