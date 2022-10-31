namespace EnemyStateMachine
{
    public abstract class EnemyBaseState
    {
        protected EnemyStateMachine m_StateMachine;

        public EnemyBaseState(EnemyStateMachine enemyStateMachine)
        {
            m_StateMachine = enemyStateMachine;
        }
        public virtual void OnEnter() { }
        public virtual void OnExit() { }
        public virtual void OnUpdate() { }
        public virtual void OnFixedUpdate() { }
        public virtual void OnCollisionEnter() { }
        public virtual void OnTriggerEnter() { }
    }
}