using ChestSlot;
using ChestMVC;
using System;
using System.Collections;
using UnityEngine;
using UIandResources;

namespace ChestStates
{
    public class ChestUnlockingState : ChestState
    {
        int TimeRemainingSeconds;
        private Coroutine countDown;

        public ChestUnlockingState(ChestStateMachine chestStateMachine) : base(chestStateMachine) { }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            chestStateMachine.GetChestController().ChestView.activeState = ChestStateEnum.Unlocking;
            UIService.Instance.DisableChestPopUp();
            chestStateMachine.GetChestController().ChestView.chestStateText.text = "Unlocking";
            ChestSlotService.Instance.IsChestUnlocking = true;
            countDown = chestStateMachine.GetChestController().ChestView.StartCoroutine(CountDown());
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
            chestStateMachine.GetChestController().ChestView.StopCoroutine(countDown);
        }        

        public IEnumerator CountDown()
        {
            TimeRemainingSeconds = chestStateMachine.GetChestController().ChestModel.ChestUnlockDuration * 60;
            while (TimeRemainingSeconds >= 0)
            {
                TimeSpan timeSpan = TimeSpan.FromSeconds(TimeRemainingSeconds);
                string timeString = timeSpan.ToString(@"hh\:mm\:ss");
                chestStateMachine.GetChestController().ChestView.chestTimerText.text = timeString;

                TimeRemainingSeconds--;
                yield return new WaitForSeconds(1);
            }
            chestStateMachine.ChangeChestState(ChestStateEnum.Unlocked);
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