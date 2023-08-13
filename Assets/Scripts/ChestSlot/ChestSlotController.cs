using UnityEngine;

namespace ChestSlot
{
    [System.Serializable]
    public class ChestSlotController : MonoBehaviour
    {
        [SerializeField] private RectTransform slotTransform;

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
}