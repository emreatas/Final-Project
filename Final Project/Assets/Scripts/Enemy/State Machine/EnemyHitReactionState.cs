using UnityEngine;

namespace Enemy
{
    public class EnemyHitReactionState : EnemyBaseState
    {
        public override void EnterState(EnemyStateManager enemy) {
            enemy.getNavMeshAgent().isStopped = true;
            enemy.anim.SetBool("isHitted" , true);
            enemy.anim.SetBool("isAttack" , false);
            enemy.anim.SetBool("isMove" , false);
            enemy.anim.SetBool("isIdle" , false);
            Debug.Log("Hit State!");
        }
        public override void UpdateState(EnemyStateManager enemy) {

        }
    }
}
