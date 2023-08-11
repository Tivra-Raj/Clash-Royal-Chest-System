using System;
using UnityEngine;

[Serializable]
public class ChestSlotController : MonoBehaviour
{
    [SerializeField] private RectTransform slotTransform;

    private bool isEmpty = true;

    public bool GetIsSlotEmpty() => isEmpty;
    public void SetSlotIsEmpty(bool value) => isEmpty = value;
    public RectTransform GetSlotTransform() => slotTransform;

    public ChestSlotType ChestSlotType;

    private void Awake()
    {
        slotTransform = GetComponent<RectTransform>();
    }

}

public enum ChestSlotType
{
    None,
    Empty,
    Filled
}