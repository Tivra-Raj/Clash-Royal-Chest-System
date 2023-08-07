using Assets.Scripts;
using ChestStates;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChestMVC
{
    public class ChestView : MonoBehaviour
    {
        public ChestController ChestController { get; private set; }
        public ChestSlotController chestSlotController;

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

        public void SetChestAtSlot(ChestSlotController slot)
        {
            chestSlotController = slot;
            chestRectTransform.position = slot.GetSlotTransform().position;

            for (int i = 0; i < ChestSlotService.Instance.slotList.Count; i++)
            {
                ChestSlotService.Instance.slotList[i].SetChestControllerAtSlot(ChestController);
            }
        }

        public ChestController GetChestFromSlot(ChestController chestController)
        {
            for (int i = 0; i < ChestSlotService.Instance.slotList.Count ; i++)
            {
                chestController =  ChestSlotService.Instance.slotList[i].GetChestControllerFromSlot();
            }
            return chestController;
        }

        private void Awake() => transform.SetParent(ChestService.Instance.ChestHolder);

        private void Start() => InitializeChestState();

        private void Update()
        {
            Debug.Log(chestCurrentState);
            chestButton.onClick.AddListener(chestCurrentState.ChestButtonAction);
            UIService.Instance.StartUnlockButton.onClick.AddListener(chestLockedState.UnlockNowChest);
        }

        public void InitialSettings()
        {
            chestImage.sprite = ChestController.ChestModel.ChestClosedImage;
        }

        private void InitializeChestState()
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