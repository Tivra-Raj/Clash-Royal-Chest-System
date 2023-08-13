using ChestMVC;

namespace ChestStates
{
    public class ChestStateMachine
    {
        private ChestController chestController;

        private ChestLockedState chestLockedState;
        private ChestUnlockingState chestUnlockingState;
        private ChestUnlockedState chestUnlockedState;
        public ChestState chestCurrentState = null;

        public ChestStateEnum currentChestStateEnum = ChestStateEnum.Locked;      

        public ChestStateMachine(ChestController chestController)
        {
            this.chestController = chestController;
            chestLockedState = new ChestLockedState(this);
            chestUnlockingState = new ChestUnlockingState(this);
            chestUnlockedState = new ChestUnlockedState(this);
            ResetChestState();
        }

        public ChestController GetChestController() => chestController;

        public ChestLockedState GetChestLockedState() => chestLockedState;
        public ChestUnlockingState GetChestUnlockingState() => chestUnlockingState;
        public ChestUnlockedState GetChestUnlockedState() => chestUnlockedState;

        public void ResetChestState()
        {
            ChangeChestState(ChestStateEnum.Locked);
        }

        public void ChangeChestState(ChestStateEnum chestState)
        {
            ChestState newState = GetChestStateFromEnum(chestState);

            if(chestCurrentState == newState) { return; }

            if (chestCurrentState != null)
            {
                chestCurrentState.OnStateExit();
            }

            chestCurrentState = newState;
            currentChestStateEnum = chestState;
            chestCurrentState.OnStateEnter();
        }

        public ChestState GetChestStateFromEnum(ChestStateEnum chestState)
        {
            if (chestState == ChestStateEnum.Locked) 
                return chestLockedState;

            else if (chestState == ChestStateEnum.Unlocking)
                return chestUnlockingState;

            else if (chestState == ChestStateEnum.Unlocked)
                return chestUnlockedState;

            else
                return null;
        }
    }
}