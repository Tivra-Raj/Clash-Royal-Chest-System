using ChestStates;
using UnityEngine;

namespace ChestMVC
{
    public class ChestController
    {
        public ChestModel ChestModel { get; private set; }
        public ChestView ChestView { get; private set; }

        public ChestStateMachine chestStateMachine;
        private int unlockDuration;
        private float gemsPerSecond { get { return 300f; } }

        public ChestController(ChestModel chestModel, ChestView chestView)
        {
            ChestModel = chestModel;
            ChestView = chestView;
            chestStateMachine = new ChestStateMachine(this);
        }

        public ChestStateMachine GetChestStateMachine() => chestStateMachine;

        public void SetChestView()
        {
            ChestView.chestImage.sprite = ChestModel.ChestClosedImage;
            SetChestTimer();
            chestStateMachine.ResetChestState();
        }        

        public void SetChestTimer()
        {
            unlockDuration = ChestModel.ChestUnlockDuration;
            ChestView.chestTimerText.text = (unlockDuration < 60) ? unlockDuration.ToString() + " Min" : (unlockDuration / 60).ToString() + " Hr";
        }

        public int GetRequiredGemsToUnlock()
        {
            int value = Mathf.CeilToInt(unlockDuration * 60 / gemsPerSecond);
            Debug.Log(value);
            return value;
        }


        public void OnChestButtonClicked()
        {
            ChestService.Instance.OnChestClicked(chestStateMachine.currentChestStateEnum, this);

            if(chestStateMachine.currentChestStateEnum == ChestStates.ChestStateEnum.Unlocked)
            {
                ChestService.Instance.DestroyChest(this);
            }
        }

        public void OnChestStartUnlocking(GameObject chestObject)
        {
            chestStateMachine.GetChestLockedState().StartUnlocking(chestObject);
        }

        public void OnChestUnlockNow(GameObject chestObject)
        {
            if(chestStateMachine.currentChestStateEnum == ChestStates.ChestStateEnum.Locked)
            {
                chestStateMachine.GetChestLockedState().UnlockNow(chestObject);
            }

            if(chestStateMachine.currentChestStateEnum == ChestStates.ChestStateEnum.Unlocking)
            {
                chestStateMachine.GetChestUnlockingState().UnlockNow(chestObject);
            }
        }
    }
}