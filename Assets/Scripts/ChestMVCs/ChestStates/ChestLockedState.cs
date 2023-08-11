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

        public override void OnChestButtonAction()
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
            ChangeChestState(chestPrefab.chestUnlockingState);
        }
        
        public void OnStateDisable()
        {
            UIService.Instance.DisableChestPopUp();
        }

        /*public int GetRequiredGemsToUnlock()
        {
            return Mathf.CeilToInt(unlockDurationMinutes * 60 / chestController.TimeSecondsPerGem);
        }*/
    }
}