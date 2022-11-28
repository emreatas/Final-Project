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
            enemy.setHitAnimationEnded(false);

        }
        public override void UpdateState(EnemyStateManager enemy) {
            if(enemy.getHitAnimationEnded()) {
                enemy.anim.SetBool("isHitted" , false);
                enemy.SwitchState(enemy.MoveState);
            }
        }
    }
}
