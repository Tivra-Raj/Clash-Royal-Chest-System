using UIandResources;
using ChestSlot;
using ChestStates;
using Utilities;
using scriptableObject;
using UnityEngine;

namespace ChestMVC
{
    public class ChestService : MonoSingletonGeneric<ChestService>
    {
        [SerializeField] private ChestScriptableObjectList ConfigChest;
        [SerializeField] private ChestView chestPrefab;
        [SerializeField] private Transform ChestHolder;

        private ChestPool chestPool;
        private ChestController ChestController;

        private void Start()
        {
            chestPool = new ChestPool(4, chestPrefab, ChestHolder);
        }

        public void SpawnChest()
        {
            ChestView chestPrefab = GetChestFromPool();

            if (chestPrefab != null)
            {
                RectTransform chestSlotTransform = ChestSlotService.Instance.GetEmptyChestSlot();
                chestPrefab.transform.SetParent(chestSlotTransform, false);
                chestPrefab.gameObject.SetActive(true);
            }
            else
            {
                UIService.Instance.EnableSlotsFullPopUp();
            }
        }

        public ChestView GetChestFromPool()
        {
            ChestView chestObject = chestPool.GetChestItem();
            if (chestObject != null)
            {
                int pickRandomChest = Random.Range(0, ConfigChest.chestScriptableObjects.Length);
                ChestScriptableObject chestScriptableObject = ConfigChest.chestScriptableObjects[pickRandomChest];

                chestObject.ChestController.ChestModel.SetChestConfiguration(chestScriptableObject);
                chestObject.ChestController.SetChestView();
                chestObject.ChestController.GetChestStateMachine().ResetChestState();
                this.ChestController = chestObject.ChestController;

                return chestObject;
            }
            return null;
        }

        public void ReturnChestToPool(ChestView chestView) => chestPool.ReturnChestItem(chestView);

        public void DestroyChest(ChestController chestController)
        {
             ReturnChestToPool(chestController.ChestView);
             ChestSlotService.Instance.ResetChestSlot(chestController.ChestView.transform.parent);
        }

        public void OnChestClicked(ChestStateEnum chestState, ChestController chestController)
        {
            UIService.Instance.OnChestClicked(chestState, chestController.ChestView.gameObject);
        }

        public void OnStartUnlocking(GameObject chestObject)
        {
            ChestController.OnChestStartUnlocking(chestObject);
        }

        public void OnUnlockNowChest(GameObject ChestObject)
        {
            ChestController.OnChestUnlockNow(ChestObject);
        }

        public void GiveRewards(GameObject chestObject)
        {
            ChestController.chestStateMachine.GetChestUnlockedState().Rewards(chestObject);
        }
    }
}