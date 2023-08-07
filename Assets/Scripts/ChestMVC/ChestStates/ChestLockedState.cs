using Assets.Scripts;
using ChestMVC;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChestStates
{
    public class ChestLockedState : ChestState
    {
        private ChestController chestController;
        private int unlockDurationMinutes;
        private Button unlockNowButton;
        private RectTransform unlockButtonRectTransform;
        private TextMeshProUGUI unlockText;
        private Button setTimerButton;
        private Vector2 centerOfChestPopUp = new Vector2(0, 0);

        public ChestLockedState(ChestController chestController)
        {
            this.chestController = chestController;
            unlockNowButton = UIService.Instance.UnlockNowButton;
            setTimerButton = UIService.Instance.StartUnlockButton;
            unlockText = UIService.Instance.UnlockText;
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            chestPrefab.activeState = ChestStateEnum.Locked;
            unlockDurationMinutes = chestPrefab.ChestController.ChestModel.ChestUnlockDuration;
            chestPrefab.chestTimerText.text = (unlockDurationMinutes < 60) ? unlockDurationMinutes.ToString() + " Min" : (unlockDurationMinutes / 60).ToString() + " Hr";
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
        }

        public override void ChestButtonAction()
        {
            //unlockText.text = "Unlock Now: " + GetRequiredGemsToUnlock().ToString();
            /*
            if (ChestService.Instance.CheckIfAnyChestUnlocking() == false)
                setTimerButton.gameObject.SetActive(true);
            else
                unlockButtonRectTransform.anchoredPosition = centerOfChestPopUp;

            unlockNowButton.onClick.AddListener(chestController.UnlockNow);
            setTimerButton.onClick.AddListener(chestController.StartUnlocking);*/
            UIService.Instance.EnableChestPopUp();
        }

        public void UnlockNowChest()
        {
            //unlockNowButton.onClick.AddListener();
            ChangeChestState(chestPrefab.chestUnlockingState);
        }

        public void OnStateEnable()
        {
            chestController.ChestView.chestStateText.text = "Locked";
            unlockDurationMinutes = chestController.ChestModel.ChestUnlockDuration;
            chestController.ChestView.chestTimerText.text = (unlockDurationMinutes < 60) ? unlockDurationMinutes.ToString() + " Min" : (unlockDurationMinutes / 60).ToString() + " Hr";
        }
        
        public void OnStateDisable()
        {
            UIService.Instance.DisableChestPopUp();
        }
        public ChestStateEnum GetChestState()
        {
            return ChestStateEnum.Locked;
        }

        /*public int GetRequiredGemsToUnlock()
        {
            return Mathf.CeilToInt(unlockDurationMinutes * 60 / chestController.TimeSecondsPerGem);
        }*/
    }
}