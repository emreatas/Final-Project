using UnityEngine;

namespace Enemy
{
    public class EnemyAttackState : EnemyBaseState
    {
        public override void EnterState(EnemyStateManager enemy) {
            enemy.anim.SetBool("isAttack" , true);
            enemy.anim.SetBool("isIdle" , false);
            enemy.anim.SetBool("isMove" , false);
            enemy.leftHand.GetComponent<Collider>().enabled = true;
            enemy.rightHand.GetComponent<Collider>().enabled = true;
            Debug.Log("Attack State!");
        }
        public override void UpdateState(EnemyStateManager enemy) {
            if(enemy.getDistanceToPlayer() > enemy.enemyStats.attackRange) {
                enemy.anim.SetBool("isAttack" , false);
                enemy.leftHand.GetComponent<Collider>().enabled = false;
                enemy.rightHand.GetComponent<Collider>().enabled = false;
                enemy.SwitchState(enemy.MoveState);
            }
            enemy.transform.LookAt(new Vector3(enemy.getTargetTransform().x , 0 , enemy.getTargetTransform().z));
        }
    }
}