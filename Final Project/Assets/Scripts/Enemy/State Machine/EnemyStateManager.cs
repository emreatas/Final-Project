using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyStateManager : MonoBehaviour
    {
        private Transform movePositionTransform;
        private NavMeshAgent navMeshAgent;
        private Vector3 bornPosition;
        private bool hitAnimationEnded;

        public Canvas canvas;
        public GameObject exclamationMark, questionMark;
        public Collider leftHand, rightHand;
        public Animator anim;
        public EnemyScriptable enemyStats;
        public EnemyBaseState currentState;
        public EnemyAttackState AttackState = new EnemyAttackState();
        public EnemyIdleState IdleState = new EnemyIdleState();
        public EnemyMoveState MoveState = new EnemyMoveState();
        public EnemyPatrollingState PatrollingState = new EnemyPatrollingState();
        public EnemyHitReactionState HitReactionState = new EnemyHitReactionState();

        private void OnEnable() {
            currentState = PatrollingState;
        }
        void Start() {
            bornPosition = this.transform.position;
            navMeshAgent = GetComponent<NavMeshAgent>();
            currentState.EnterState(this);
        }
        void Update() {
            currentState.UpdateState(this);
            if(getDistanceToPlayer() < enemyStats.exclamationRange && getDistanceToPlayer() >= enemyStats.sightRange) {
                questionMark.SetActive(true);
            }
            else {
                questionMark.SetActive(false);
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
            return Vector3.Distance(this.transform.position , getTargetTransform());
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
        public void HitAnimationEnded() {
            hitAnimationEnded = true;
        }
        public bool getHitAnimationEnded() {
            return hitAnimationEnded;
        }
        public void setHitAnimationEnded(bool hitBool) {
            hitAnimationEnded = hitBool;
        }
        public void setPlayerTransform(Transform player) {
            movePositionTransform = player;
        }
        public void setBilboardCamera(Transform cam) {
            canvas.GetComponent<Billboard>().setCameraTransform(cam);
        }
        public bool getIsEnemyDisabled() {
            return this.enabled;
        }
    }
}
