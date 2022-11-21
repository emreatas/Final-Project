using UnityEngine;
using MEC;
using System.Collections.Generic;

namespace Enemy
{
    public class EnemyPatrollingState : EnemyBaseState
    {
        bool hasTargetPoint;
        public override void EnterState(EnemyStateManager enemy) {
            Debug.Log("Patrolling State!");
            hasTargetPoint = false;
        }
        public override void UpdateState(EnemyStateManager enemy) {
            if(enemy.getNavMeshAgent().remainingDistance <= enemy.getNavMeshAgent().stoppingDistance) {
                Vector3 point;
                if(!hasTargetPoint) {
                    if(enemy.CreateRandomPoints(out point)) {
                        hasTargetPoint = true;
                        Timing.RunCoroutine(_HappyWaiting(enemy , point));
                    }
                }
            }
            if(enemy.getDistanceToPlayer() < enemy.enemyStats.sightRange) {
                Timing.KillCoroutines();
                enemy.SwitchState(enemy.MoveState);
            }
        }
        IEnumerator<float> _HappyWaiting(EnemyStateManager enemy , Vector3 point) {
            enemy.getNavMeshAgent().isStopped = true;
            enemy.anim.SetBool("isIdle" , true);
            enemy.anim.SetBool("isMove" , false);
            yield return Timing.WaitForSeconds(3f);
            enemy.getNavMeshAgent().isStopped = false;
            enemy.anim.SetBool("isIdle" , false);
            enemy.anim.SetBool("isMove" , true);
            enemy.getNavMeshAgent().SetDestination(point);
            hasTargetPoint = false;
        }
    }
}