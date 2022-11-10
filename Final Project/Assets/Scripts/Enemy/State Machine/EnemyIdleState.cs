using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy) {
        enemy.anim.SetBool("isMove" , false);
        enemy.getNavMeshAgent().isStopped = true;
    }
    public override void UpdateState(EnemyStateManager enemy) {
        if(Vector3.Distance(enemy.transform.position , enemy.getTargetTransform().position) <= enemy.enemyStats.sightRange) {
            enemy.SwitchState(enemy.MoveState);
        }
    }
    public override void OnCollisionEnter(EnemyStateManager enemy) {

    }
}
