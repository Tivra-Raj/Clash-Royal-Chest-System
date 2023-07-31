using UnityEngine;

namespace ChestMVC
{
    [CreateAssetMenu(fileName = "NewChest", menuName = "SriptableObjects/CreateNewChest")]
    public class ChestScriptableObject : ScriptableObject
    {
        public Sprite ChestClosedImage;
        public Sprite ChestOpenImage;

        public int MinimumRewardCoins;
        public int MaximumRewardCoins;

        public int MinimumRewardGems;
        public int MaximumRewardGems;

        public int ChestUnlockDuration; //in minutes

        public ChestView ChestPrefab;
    }
}