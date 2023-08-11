using ChestStates;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChestMVC
{
    public class ChestView : MonoBehaviour
    {
        public ChestController ChestController { get; private set; }

        private ChestSlotController chestSlotController;

        [SerializeField] private RectTransform chestRectTransform;
        [SerializeField] public Image chestImage;
        [SerializeField] public Button chestButton;
        [SerializeField] public TextMeshProUGUI chestStateText;
        [SerializeField] public TextMeshProUGUI chestTimerText;

        [Header("Chest states")]
        public ChestLockedState chestLockedState;
        public ChestUnlockingState chestUnlockingState;
        public ChestUnlockedState chestUnlockedState;
        public ChestState chestCurrentState;


        [SerializeField] private ChestStateEnum initialState;
        public ChestStateEnum activeState;

        public int TimeRemainingSeconds { get; private set; }

        public void SetChestController(ChestController chestController) => ChestController = chestController;

        public void SetChestPosition(ChestSlotController slotPosition)
        {
            chestSlotController = slotPosition;
            chestRectTransform.position = chestSlotController.GetSlotTransform().position;
        }

        private void Start()
        {
            chestButton.onClick.AddListener(chestCurrentState.OnChestButtonAction);
        }

        /*public void OnChestClicked()
        {
            chestController.OnChestButtonClicked();
        }*/

        public void InitializeChestState()
        {
            switch (initialState)
            {
                case ChestStateEnum.Locked:
                    chestCurrentState = chestLockedState;
                    break;
                case ChestStateEnum.Unlocking:
                    chestCurrentState = chestUnlockingState;
                    break;
                case ChestStateEnum.Unlocked:
                    chestCurrentState = chestUnlockedState;
                    break;
                default:
                    chestCurrentState = null;
                    break;
            }
            chestCurrentState.OnStateEnter();
        }
    }
}