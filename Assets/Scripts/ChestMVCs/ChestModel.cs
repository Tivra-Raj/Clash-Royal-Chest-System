using scriptableObject;
using UnityEngine;

namespace ChestMVC
{
    public class ChestModel
    {
        public Sprite ChestClosedImage { get; private set; }
        public Sprite ChestOpenImage { get; private set; }
        public int MinimumRewardCoins { get; private set; }
        public int MaximumRewardCoins { get; private set; }
        public int MinimumRewardGems { get; private set; }
        public int MaximumRewardGems { get; private set; }
        public int ChestUnlockDuration { get; private set; }

        public ChestType CHEST_TYPE { get; private set; }

        private ChestController chestController;

        public void SetChestConfiguration(ChestScriptableObject chestScriptableObject)
        {
            ChestClosedImage = chestScriptableObject.ChestClosedImage;
            ChestOpenImage = chestScriptableObject.ChestOpenImage;

            MinimumRewardCoins = chestScriptableObject.MinimumRewardCoins;
            MaximumRewardCoins = chestScriptableObject.MaximumRewardCoins;

            MinimumRewardGems = chestScriptableObject.MinimumRewardGems;
            MaximumRewardGems = chestScriptableObject.MaximumRewardGems;

            ChestUnlockDuration = chestScriptableObject.ChestUnlockDuration;
        }

        public void SetChestController(ChestController chestController) => this.chestController = chestController;

        /*public void UpdateUnlockTime(float deltaTime)
        {
            UNLOCK_TIME = Mathf.Max(UNLOCK_TIME - deltaTime, 0);
            GEMS_TO_UNLOCK = (int)Mathf.Ceil((UNLOCK_TIME / MAX_UNLOCK_TIME) * MAX_GEMS_TO_UNLOCK);
        }*/

    }

    public enum ChestType
    {
        None,
        Common,
        Rare,
        Epic,
        Legendary,
    }
}