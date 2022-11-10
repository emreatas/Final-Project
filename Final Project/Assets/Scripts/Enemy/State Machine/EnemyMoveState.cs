using UnityEngine;

public class EnemyMoveState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy) {
        enemy.anim.SetBool("isMove" , true);
        enemy.getNavMeshAgent().isStopped = false;
    }
    public override void UpdateState(EnemyStateManager enemy) {
        if(enemy.getDistanceToPlayer() > enemy.enemyStats.sightRange) {
            if(enemy.getDistanceToBornPosition() < 1f) {
                enemy.anim.SetBool("isMove" , false);
                enemy.SwitchState(enemy.IdleState);
            }
            else {
                enemy.getNavMeshAgent().destination = enemy.getBornTransform();
            }
        }
        else if(enemy.getDistanceToPlayer() <= enemy.enemyStats.sightRange) {
            if(enemy.getDistanceToPlayer() > enemy.enemyStats.attackRange) {
                enemy.getNavMeshAgent().isStopped = false;
                enemy.getNavMeshAgent().destination = enemy.getTargetTransform();
            }
            else if(enemy.getDistanceToPlayer() <= enemy.enemyStats.attackRange) {
                enemy.getNavMeshAgent().isStopped = true;
                enemy.anim.SetBool("isMove" , false);
                enemy.SwitchState(enemy.AttackState);
            }
        }
    }
    public override void OnTriggerEnter(EnemyStateManager enemy , Collider other) {

    }
}
