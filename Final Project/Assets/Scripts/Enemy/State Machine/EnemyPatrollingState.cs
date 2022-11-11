using UnityEngine;
using MEC;
using System.Collections.Generic;

public class EnemyPatrollingState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy) {

    }
    public override void UpdateState(EnemyStateManager enemy) {
        if(enemy.getNavMeshAgent().remainingDistance <= enemy.getNavMeshAgent().stoppingDistance) {
            Vector3 point;
            if(enemy.CreateRandomPoints(out point)) {
                Timing.RunCoroutine(_HappyWaiting(enemy));
                Debug.DrawRay(point , Vector3.up , Color.blue , 1.0f);
                enemy.anim.SetBool("isMove" , true);
                enemy.getNavMeshAgent().SetDestination(point);
            }
        }
        if(enemy.getDistanceToPlayer() < enemy.enemyStats.sightRange) {
            Timing.KillCoroutines();
            enemy.SwitchState(enemy.MoveState);
        }
    }
    public override void OnTriggerEnter(EnemyStateManager enemy , Collider other) {

    }
    IEnumerator<float> _HappyWaiting(EnemyStateManager enemy) {
        enemy.anim.SetBool("isMove" , false);
        yield return Timing.WaitForSeconds(1f);
    }
}