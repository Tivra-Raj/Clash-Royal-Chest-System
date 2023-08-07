using ChestMVC;
using System;
using UnityEngine;

[Serializable]
public class ChestSlotController
{
    [SerializeField] private RectTransform slotTransform;

    private ChestController chestController;
    private bool isEmpty = true;

    public bool GetIsSlotEmpty() => isEmpty;
    public void SetSlotIsEmpty(bool value) => isEmpty = value;
    public RectTransform GetSlotTransform() => slotTransform;

    public void SetChestControllerAtSlot(ChestController controller) => chestController = controller;
    public ChestController GetChestControllerFromSlot() => chestController;
}