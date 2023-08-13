namespace ChestStates
{
    public class ChestState
    {
        protected ChestStateMachine chestStateMachine;

        public ChestState(ChestStateMachine chestStateMachine)
        {
            this.chestStateMachine = chestStateMachine;
        }

        public virtual void OnStateEnter() { }

        public virtual void OnStateExit() { }
    }
}