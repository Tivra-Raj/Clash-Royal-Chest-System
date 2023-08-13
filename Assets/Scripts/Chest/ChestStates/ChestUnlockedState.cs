using ChestSlot;
using ChestMVC;
using UnityEngine;
using UIandResources;

namespace ChestStates
{
    public class ChestUnlockedState : ChestState
    {
        public ChestUnlockedState(ChestStateMachine chestStateMachine) : base(chestStateMachine) { }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            ChestController chestController = chestStateMachine.GetChestController();
            chestController.ChestView.activeState = ChestStateEnum.Unlocked;
            chestController.ChestView.chestStateText.text = "Unlocked";
            chestController.ChestView.chestTimerText.enabled = false;
            ChestSlotService.Instance.IsChestUnlocking = false;
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
            
            UIService.Instance.DisableRewardPopUp();
        }

        public void Rewards()
        {
            ChestController chestController = chestStateMachine.GetChestController();
            int coinsMin = chestController.ChestModel.MinimumRewardCoins;
            int coinsMax = chestController.ChestModel.MaximumRewardCoins;
            int gemsMin = chestController.ChestModel.MinimumRewardGems;
            int gemsMax = chestController.ChestModel.MaximumRewardGems;

            int RewardCoins = Random.Range(coinsMin, coinsMax + 1);
            int RewardGems = Random.Range(gemsMin, gemsMax + 1);

            UIService.Instance.RewardCoinText.text = "" + RewardCoins.ToString();
            UIService.Instance.RewardGemText.text = "" + RewardGems.ToString();

            ResourceService.Instance.IncrementCoins(RewardCoins);
            ResourceService.Instance.IncrementGems(RewardGems);
        }
    }
}