using ChestSystem.Utilities;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class ChestSlotService : MonoSingletonGeneric<ChestSlotService>
    {
        [SerializeField] private List<ChestSlotController> slotList;

        public ChestSlotController GetEmptySlot()
        {
            ChestSlotController chestSlotController = null;
            for(int i=0; i < slotList.Count; i++)
            {
                if (slotList[i].GetIsSlotEmpty())
                {
                    chestSlotController = slotList[i];
                    chestSlotController.SetSlotIsEmpty(false);
                    break;
                }
            }
            return chestSlotController;
        }
    }
}