namespace StateMachine
{
    public abstract class BaseState
    {
        protected FiniteStateMachine m_StateMachine;

        public BaseState(FiniteStateMachine stateMachine)
        {
            m_StateMachine = stateMachine;
        }
        
        public virtual void OnEnter(){}
        public virtual void OnExit(){}
        public virtual void OnUpdate(){}
        public virtual void OnFixedUpdate(){}
        public virtual void OnCollisionEnter(){}
        public virtual void OnTriggerEnter(){}
    }
}
