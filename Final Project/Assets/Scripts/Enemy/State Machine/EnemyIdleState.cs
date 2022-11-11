using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy) {
        enemy.getNavMeshAgent().isStopped = true;
    }
    public override void UpdateState(EnemyStateManager enemy) {
        if(enemy.getDistanceToPlayer() <= enemy.enemyStats.sightRange) {
            enemy.SwitchState(enemy.MoveState);
        }
    }
    public override void OnTriggerEnter(EnemyStateManager enemy , Collider other) {

    }
}
