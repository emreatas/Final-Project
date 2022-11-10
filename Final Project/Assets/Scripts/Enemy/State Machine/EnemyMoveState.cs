using UnityEngine;

public class EnemyMoveState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy) {
        enemy.anim.SetBool("isMove" , true);
        enemy.getNavMeshAgent().isStopped = false;
    }
    public override void UpdateState(EnemyStateManager enemy) {
        enemy.getNavMeshAgent().destination = enemy.getTargetTransform().position;
        if(Vector3.Distance(enemy.transform.position , enemy.getTargetTransform().position) > enemy.enemyStats.sightRange) {
            enemy.SwitchState(enemy.IdleState);
        }
    }
    public override void OnCollisionEnter(EnemyStateManager enemy) {

    }
}
