namespace StateMachine
{
    public class IdleState : BaseState
    {
        public IdleState(FiniteStateMachine stateMachine) : base(stateMachine) { }

        public override void OnUpdate()
        {
        }
    }
}