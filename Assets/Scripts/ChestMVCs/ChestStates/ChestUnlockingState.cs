using Assets.Scripts;
using System;
using System.Collections;
using UnityEngine;

namespace ChestStates
{
    public class ChestUnlockingState : ChestState
    {
        int TimeRemainingSeconds;
        private Coroutine countDown;

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            chestPrefab.activeState = ChestStateEnum.Unlocking;
            UIService.Instance.DisableChestPopUp();
            chestPrefab.chestStateText.text = "Unlocking";
            countDown = StartCoroutine(CountDown());
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
            StopCoroutine(countDown);
        }

        public override void OnChestButtonAction()
        {
            //unlockText.text = "Unlock Now: " + GetRequiredGemsToUnlock().ToString();
            /*unlockNowButton.gameObject.SetActive(true);

            if (ChestService.Instance.CheckIfAnyChestUnlocking() == false)
                setTimerButton.gameObject.SetActive(true);
            else
                unlockButtonRectTransform.anchoredPosition = centerOfChestPopUp;

            unlockNowButton.onClick.AddListener(chestController.UnlockNow);
            setTimerButton.onClick.AddListener(chestController.StartUnlocking);*/
            UIService.Instance.EnableChestPopUp();
        }

        public IEnumerator CountDown()
        {
            TimeRemainingSeconds = chestPrefab.ChestController.ChestModel.ChestUnlockDuration / 60;
            while (TimeRemainingSeconds >= 0)
            {
                TimeSpan timeSpan = TimeSpan.FromSeconds(TimeRemainingSeconds);
                string timeString = timeSpan.ToString(@"hh\:mm\:ss");
                chestPrefab.chestTimerText.text = timeString;

                TimeRemainingSeconds--;
                yield return new WaitForSeconds(1);
            }
            ChangeChestState(chestPrefab.chestUnlockedState);
        }
    }
}