using Assets.Scripts;
using ChestSystem.Utilities;
using UnityEngine;

namespace ChestMVC
{
    public class ChestService : MonoSingletonGeneric<ChestService>
    {
        public ChestScriptableObject[] ConfigChest;

        public ChestController ChestController { get; private set; }
        private ChestPool chestPool;

        public RectTransform ChestHolder;

        private void Start()
        {
            chestPool = GetComponent<ChestPool>();

            for (int i = 0; i < 4; i++)
            {
                SpawnRandomChest();
            }
        }

        private void SpawnRandomChest()
        {
            CreateNewChest();
        }

        private ChestController CreateNewChest()
        {
            ChestSlotController slot = ChestSlotService.Instance.GetEmptySlot();

            int pickRandomTank = Random.Range(0, ConfigChest.Length);

            ChestScriptableObject chestScriptableObject = ConfigChest[pickRandomTank];
            ChestModel chestModel = new ChestModel(chestScriptableObject);
           
            ChestController = chestPool.GetChest(chestModel, chestScriptableObject.ChestPrefab);
            ChestController.ChestView.InitialSettings();
            ChestController.ChestView.SetChestAtSlot(slot);

            return ChestController;
        }

        public void ReturnChestToPool(ChestController chestToReturn) => chestPool.ReturnItem(chestToReturn);
    }
}