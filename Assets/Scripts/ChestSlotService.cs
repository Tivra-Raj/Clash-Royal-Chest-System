﻿using ChestSystem.Utilities;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class ChestSlotService : MonoSingletonGeneric<ChestSlotService>
    {
        [SerializeField] public List<ChestSlotController> slotList;

        public ChestSlotController ChestSlotController { get; private set; }

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

        /*public RectTransform GetChestSlotPosition()
        {
            for (int i = 0; i < slotList.Count; i++)
            {
                slotTransform = slotList[i].GetSlotTransform();
            }
            return slotTransform;
        }*/

    }
}