using Assets.Scripts;

namespace ChestStates
{
    public class ChestUnlockedState : ChestState
    {
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            chestPrefab.activeState = ChestStateEnum.Unlocked;
            chestPrefab.chestStateText.text = "Unlocked";
            chestPrefab.chestTimerText.enabled = false;
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
            UIService.Instance.DisableRewardPopUp();
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
            UIService.OnChestPopUpClosed += DestroyChest;
            UIService.Instance.EnableRewardPopUp();
        }

        private void DestroyChest()
        {
            UIService.OnChestPopUpClosed -= DestroyChest;
            OnStateExit();
            //chestPrefab.DestroyChest();
        }
    }
}