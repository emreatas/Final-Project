using UnityEngine;

namespace Enemy
{
    public class EnemyIdleState : EnemyBaseState
    {
        public override void EnterState(EnemyStateManager enemy) {
            enemy.getNavMeshAgent().isStopped = true;
            enemy.anim.SetBool("isIdle" , true);
            Debug.Log("Idle State!");
        }
        public override void UpdateState(EnemyStateManager enemy) {
            if(enemy.getDistanceToPlayer() <= enemy.enemyStats.sightRange) {
                enemy.SwitchState(enemy.MoveState);
            }
        }
    }
}
