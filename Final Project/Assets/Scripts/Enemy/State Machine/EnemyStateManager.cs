using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;
    private NavMeshAgent navMeshAgent;
    private Vector3 bornPosition;

    public GameObject exclamationMark;
    public Collider leftHand, rightHand;
    public Animator anim;
    public EnemyScriptable enemyStats;
    public EnemyBaseState currentState;
    public EnemyAttackState AttackState = new EnemyAttackState();
    public EnemyIdleState IdleState = new EnemyIdleState();
    public EnemyMoveState MoveState = new EnemyMoveState();
    public EnemyPatrollingState PatrollingState = new EnemyPatrollingState();
    public EnemyHitReactionState HitReactionState = new EnemyHitReactionState();

    void Start() {
        bornPosition = this.transform.position;
        currentState = PatrollingState;
        navMeshAgent = GetComponent<NavMeshAgent>();
        currentState.EnterState(this);
    }
    void Update() {
        currentState.UpdateState(this);
        if(getDistanceToPlayer() < enemyStats.exclamationRange && getDistanceToPlayer() >= enemyStats.sightRange) {
            exclamationMark.SetActive(true);
        }
        else {
            exclamationMark.SetActive(false);
        }
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
        return movePositionTransform.position;
    }
    public Vector3 getBornTransform() {
        return this.bornPosition;
    }
    public float getDistanceToPlayer() {
        return Vector3.Distance(new Vector3(this.transform.position.x , this.transform.position.y + enemyStats.positionDiffWithPrefab , this.transform.position.z) , getTargetTransform());
    }
    public float getDistanceToBornPosition() {
        return Vector3.Distance(this.transform.position , getBornTransform());
    }
    public bool CreateRandomPoints(out Vector3 result) {
        Vector3 randomPoint = getBornTransform() + Random.insideUnitSphere * enemyStats.patrolRadius;
        NavMeshHit hit;
        if(NavMesh.SamplePosition(randomPoint , out hit , 1.0f , NavMesh.AllAreas)) {
            result = hit.position;
            return true;
        }
        result = Vector3.zero;
        return false;
    }
    public void EnableColliders() {
        leftHand.enabled = true;
        rightHand.enabled = true;
    }
    public void DisableColliders() {
        leftHand.enabled = false;
        rightHand.enabled = false;
    }
    public void SwitchStateFromHitReaction() {
        anim.SetBool("isHitted" , false);
        SwitchState(MoveState);
    }
}
