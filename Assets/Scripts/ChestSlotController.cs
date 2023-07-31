using System;
using UnityEngine;

[Serializable]
public class ChestSlotController
{
    [SerializeField] private RectTransform slotTransform;

    //private ChestController chestController;
    private bool isEmpty = true;

    //public void SetController(ChestSlotController controller) => chestController = controller;
    //public ChestController GetController() => chestController;
    public bool GetIsSlotEmpty() => isEmpty;
    public void SetSlotIsEmpty(bool value) => isEmpty = value;
    public RectTransform GetSlotTransform() => slotTransform;
}