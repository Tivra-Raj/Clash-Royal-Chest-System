using ChestStates;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChestMVC
{
    public class ChestView : MonoBehaviour
    {
        public ChestController ChestController { get; private set; }

        [SerializeField] private RectTransform chestRectTransform;
        [SerializeField] public Image chestImage;
        [SerializeField] public Button chestButton;
        [SerializeField] public TextMeshProUGUI chestStateText;
        [SerializeField] public TextMeshProUGUI chestTimerText;

        [SerializeField] private ChestStateEnum initialState;
        public ChestStateEnum activeState;

        public void SetChestController(ChestController chestController) => ChestController = chestController;

        private void Start()
        {
            chestButton.onClick.AddListener(ChestController.OnChestButtonClicked);
        }
    }
}