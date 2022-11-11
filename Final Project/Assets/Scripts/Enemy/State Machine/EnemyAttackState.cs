using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy) {
        enemy.anim.SetBool("isAttack" , true);
    }
    public override void UpdateState(EnemyStateManager enemy) {
        if(enemy.getDistanceToPlayer() > enemy.enemyStats.attackRange) {
            enemy.anim.SetBool("isAttack" , false);
            enemy.SwitchState(enemy.MoveState);
        }
        enemy.transform.LookAt(new Vector3(enemy.getTargetTransform().x,0,enemy.getTargetTransform().z));
    }
    public override void OnTriggerEnter(EnemyStateManager enemy, Collider other) {
        IHealth player = other.GetComponent<IHealth>();
        if(player != null) {
            player.TakeDamage(enemy.enemyStats.damage);
        }
    }
}