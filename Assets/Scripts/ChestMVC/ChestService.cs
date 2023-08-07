using Assets.Scripts;
using ChestStates;
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
        }


        public void SpawnRandomChest()
        {
            ChestSlotController slot = ChestSlotService.Instance.GetEmptySlot();
            if (slot == null)
            {
                UIService.Instance.EnableSlotsFullPopUp();
                return;
            }
            CreateNewChest(slot);
        }

        private ChestController CreateNewChest(ChestSlotController slot)
        {
            int pickRandomChest = Random.Range(0, ConfigChest.Length);

            ChestScriptableObject chestScriptableObject = ConfigChest[pickRandomChest];
            ChestModel chestModel = new ChestModel(chestScriptableObject);
           
            ChestController = chestPool.GetChest(chestModel, chestScriptableObject.ChestPrefab);
            ChestController.ChestView.InitialSettings();
            ChestController.ChestView.SetChestAtSlot(slot);

            return ChestController;
        }

        public void ReturnChestToPool(ChestController chestToReturn) => chestPool.ReturnItem(chestToReturn);

        public bool CheckIfAnyChestUnlocking()
        {
            for (int i = 0; i < ChestSlotService.Instance.slotList.Count; i++)
            {
                ChestSlotController chestSlotController = ChestSlotService.Instance.slotList[i];
                if (chestSlotController.GetChestControllerFromSlot().ChestView.activeState == ChestStateEnum.Unlocking)
                {
                    return true;
                }
            }
            return false;
        }
    }
}