using ChestSystem.Utilities;
using UnityEngine;

namespace Assets.Scripts
{
    public class ChestSlotService : MonoSingletonGeneric<ChestSlotService>
    {

        [SerializeField] private ChestSlotController[] chestSlots;

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

        public void ResetChestSlot(RectTransform chestSlotTransform)
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