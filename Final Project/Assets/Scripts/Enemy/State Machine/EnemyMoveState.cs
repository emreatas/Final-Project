using UnityEngine;

public class EnemyMoveState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy) {
        enemy.anim.SetBool("isMove" , true);
        enemy.getNavMeshAgent().isStopped = false;
    }
    public override void UpdateState(EnemyStateManager enemy) {
        if(enemy.getDistanceToPlayer() > enemy.enemyStats.sightRange) {
            enemy.exclamationMark.SetActive(false);
            if(enemy.getDistanceToBornPosition() < 1f) {
                enemy.anim.SetBool("isMove" , false);
                enemy.SwitchState(enemy.PatrollingState);
            }
            else {
                enemy.getNavMeshAgent().destination = enemy.getBornTransform();
            }
        }
        else if(enemy.getDistanceToPlayer() <= enemy.enemyStats.sightRange) {
            if(enemy.getDistanceToPlayer() > enemy.enemyStats.attackRange) {
                enemy.exclamationMark.SetActive(true);
                enemy.getNavMeshAgent().isStopped = false;
                enemy.getNavMeshAgent().destination = enemy.getTargetTransform();
            }
            else if(enemy.getDistanceToPlayer() <= enemy.enemyStats.attackRange) {
                enemy.exclamationMark.SetActive(false);
                enemy.getNavMeshAgent().isStopped = true;
                enemy.anim.SetBool("isMove" , false);
                enemy.SwitchState(enemy.AttackState);
            }
        }
    }
}
