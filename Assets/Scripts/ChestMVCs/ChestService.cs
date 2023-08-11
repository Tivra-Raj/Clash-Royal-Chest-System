using ChestSystem.Utilities;
using scriptableObject;
using UnityEngine;

namespace ChestMVC
{
    public class ChestService : MonoSingletonGeneric<ChestService>
    {
        [SerializeField] private ChestScriptableObjectList ConfigChest;
        [SerializeField] private ChestView chestPrefab;
        [SerializeField] private RectTransform ChestHolder;

        private ChestPool chestPool;

        private void Start()
        {
            chestPool = new ChestPool(4, chestPrefab, ChestHolder);
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
                chestObject.ChestController.GetChestStateMachine();

                //chestObject.GetChestController().GetChestSM().ResetSM();

                return chestObject;
            }
            return null;
        }

        public void ReturnChestToPool(ChestView chestView) => chestPool.ReturnChestItem(chestView);


        /*public void SpawnRandomChest()
        {
            ChestSlotController slot = ChestSlotService.Instance.GetEmptySlot();

            if (slot == null)
            {
                UIService.Instance.EnableSlotsFullPopUp();
                return;
            }

            // CreateNewChest(slot);
        }*/

        /*public bool IsAnyChestUnlocking()
        {
            int numberOfSlots = SlotService.Instance.GetNumberOfSlots();
            for (int i = 0; i < numberOfSlots; i++)
            {
                ChestSlot slot = SlotService.Instance.GetSlotAtPos(i);
                if (slot.GetController().ChestState == ChestState.UNLOCKING)
                {
                    return true;
                }
            }
            return false;
        }
*/
    }
}