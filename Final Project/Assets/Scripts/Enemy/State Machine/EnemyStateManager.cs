using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;
    private NavMeshAgent navMeshAgent;
    private Vector3 bornPosition;

    public GameObject leftHand, rightHand;
    public Animator anim;
    public EnemyScriptable enemyStats;
    public EnemyBaseState currentState;
    public EnemyAttackState AttackState = new EnemyAttackState();
    public EnemyIdleState IdleState = new EnemyIdleState();
    public EnemyMoveState MoveState = new EnemyMoveState();

    void Start()
    {
        bornPosition = this.transform.position;
        currentState = IdleState;
        navMeshAgent = GetComponent<NavMeshAgent>();
        currentState.EnterState(this);
    }
    void Update()
    {
        currentState.UpdateState(this);
    }
    public void SwitchState(EnemyBaseState state) {
        currentState = state;
        Debug.Log("State: " + state.ToString());
        state.EnterState(this);
    }
    public NavMeshAgent getNavMeshAgent() {
        return this.navMeshAgent;
    }
    public Vector3 getTargetTransform() {
        return new Vector3(this.movePositionTransform.position.x,0,this.movePositionTransform.position.z);
    }
    public Vector3 getBornTransform() {
        return this.bornPosition;
    }
    public float getDistanceToPlayer() {
        return Vector3.Distance(new Vector3(this.transform.position.x , 0 , this.transform.position.z) , getTargetTransform());
    }
    public float getDistanceToBornPosition() {
        return Vector3.Distance(new Vector3(this.transform.position.x , 0 , this.transform.position.z) , getBornTransform());
    }
}
