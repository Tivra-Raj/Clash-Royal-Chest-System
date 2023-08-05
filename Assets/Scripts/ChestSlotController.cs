using System;
using UnityEngine;

[Serializable]
public class ChestSlotController
{
    [SerializeField] private RectTransform slotTransform;

    private bool isEmpty = true;

    public bool GetIsSlotEmpty() => isEmpty;
    public void SetSlotIsEmpty(bool value) => isEmpty = value;
    public RectTransform GetSlotTransform() => slotTransform;
}