using UnityEngine;

public class EnemyHitReactionState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy) {
        enemy.anim.SetBool("isHitted" , true);
        enemy.anim.SetBool("isAttack" , false);
        enemy.anim.SetBool("isMove" , false);
    }
    public override void UpdateState(EnemyStateManager enemy) {

    }
}