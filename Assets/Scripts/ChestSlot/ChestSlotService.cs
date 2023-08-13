using Utilities;
using UnityEngine;

namespace ChestSlot
{
    public class ChestSlotService : MonoSingletonGeneric<ChestSlotService>
    {

        [SerializeField] private ChestSlotController[] chestSlots;

        public bool IsChestUnlocking = false;

        public RectTransform GetEmptyChestSlot()
        {
            for (int i = 0; i < chestSlots.Length; i++)
            {
                if (chestSlots[i].ChestSlotType == ChestSlotType.Empty)
                {
                    chestSlots[i].ChestSlotType = ChestSlotType.Filled;
                    return chestSlots[i].GetSlotTransform();
                }
            }
            return null;
        }

        public void ResetChestSlot(Transform chestSlotTransform)
        {
            for (int i = 0; i < chestSlots.Length; i++)
            {
                if (chestSlots[i].gameObject == chestSlotTransform.gameObject)
                {
                    chestSlots[i].ChestSlotType = ChestSlotType.Empty;
                    break;
                }
            }
        }
    }
}