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

        }
        public override void UpdateState(EnemyStateManager enemy) {
            if(enemy.getDistanceToPlayer() > enemy.enemyStats.attackRange) {
                enemy.anim.SetBool("isAttack" , false);
                enemy.leftHand.GetComponent<Collider>().enabled = false;
                enemy.rightHand.GetComponent<Collider>().enabled = false;
                enemy.SwitchState(enemy.MoveState);
            }

            Vector3 dir = (enemy.getTargetTransform() - enemy.transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(dir);
            rotation.x = 0;
            rotation.z = 0;
            enemy.transform.rotation = rotation;
            //enemy.transform.LookAt(new Vector3(0 ,  enemy.getTargetTransform().y ,0));
        }
    }
}