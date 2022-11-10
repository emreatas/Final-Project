using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;
    private NavMeshAgent navMeshAgent;

    public Animator anim;
    public EnemyScriptable enemyStats;
    public EnemyBaseState currentState;
    public EnemyAttackState AttackState = new EnemyAttackState();
    public EnemyIdleState IdleState = new EnemyIdleState();
    public EnemyMoveState MoveState = new EnemyMoveState();

    public void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        currentState = IdleState;
        currentState.EnterState(this);
    }
    void Update()
    {
        currentState.UpdateState(this);
    }
    public void SwitchState(EnemyBaseState state) {
        currentState = state;
        state.EnterState(this);
    }
    public NavMeshAgent getNavMeshAgent() {
        return this.navMeshAgent;
    }
    public Transform getTargetTransform() {
        return this.movePositionTransform;
    }
}
