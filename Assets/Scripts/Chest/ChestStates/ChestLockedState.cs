using UIandResources;
using ChestMVC;
using UnityEngine;

namespace ChestStates
{
    public class ChestLockedState : ChestState
    {
        public ChestLockedState(ChestStateMachine chestStateMachine) : base(chestStateMachine) { }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            ChestController chestController = chestStateMachine.GetChestController();
            chestController.ChestView.activeState = ChestStateEnum.Locked;
            chestController.ChestView.chestStateText.text = "Tap to Unlock";
            chestController.ChestView.chestTimerText.enabled = true;
            chestController.SetChestTimer();
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
        }

        public void StartUnlocking(GameObject chestObject)
        {
            ChestController chestController = chestObject.GetComponent<ChestView>().ChestController;
            chestController.GetChestStateMachine().ChangeChestState(ChestStateEnum.Unlocking);
        }

        public void UnlockNow(GameObject chestObject)
        {
            ChestController chestController = chestObject.GetComponent<ChestView>().ChestController;
            if (ResourceService.Instance.GetGems() >= chestController.GetRequiredGemsToUnlock())
            {
                chestController.GetChestStateMachine().ChangeChestState(ChestStateEnum.Unlocked);
                ResourceService.Instance.DecrementGems(chestController.GetRequiredGemsToUnlock());
                UIService.Instance.DisableChestPopUp();
            }
            else
            {
                UIService.Instance.DisableChestPopUp();
                UIService.Instance.EnableInsufficiantResourcePopUp();
            }
        }
    }
}