using ChestMVC;
using ChestSystem.Utilities;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class UIService : MonoSingletonGeneric<UIService>
    {
        public Vector2 UnlockButtonInitialPos { get; private set; }
        public Button UnlockNowButton { get { return unlockNowButton; } private set { } }
        public Button SetTimerButton { get { return setTimerButton; } private set { } }
        public TextMeshProUGUI GiftCoinText { get { return giftCoinText; } private set { } }
        public TextMeshProUGUI GiftGemText { get { return giftGemText; } private set { } }

        public TextMeshProUGUI UnlockText { get { return unlockText; } private set { } }

        [Header("Chest Related Buttons")]
        [SerializeField] private Button createChestButton;
        [SerializeField] private GameObject chestSlotsFullPopUp;
        [SerializeField] private Button closeChestSlotsFull;

        [Header("Chest Pop Up")]
        [SerializeField] private GameObject chestPopUp;
        [SerializeField] private Button closeChestPopUp;
        [SerializeField] private Button unlockNowButton;
        [SerializeField] private TextMeshProUGUI unlockText;
        [SerializeField] private Button setTimerButton;
        [SerializeField] private GameObject rewardPopUp;
        [SerializeField] private TextMeshProUGUI giftCoinText;
        [SerializeField] private TextMeshProUGUI giftGemText;

        [Header("Player Stats")]
        [SerializeField] private TextMeshProUGUI coins;
        [SerializeField] private TextMeshProUGUI gems;


        public static event Action OnChestPopUpClosed;

        public void RefreshPlayerStats()
        {
            coins.text = ResourceService.Instance.GetCoinsInAccount().ToString();
            gems.text = ResourceService.Instance.GetGemsInAccount().ToString();
        }
        public void EnableChestPopUp()
        {
            chestPopUp.SetActive(true);
        }
        public void DisableChestPopUp()
        {
            chestPopUp.SetActive(false);
            unlockNowButton.gameObject.SetActive(false);
            setTimerButton.gameObject.SetActive(false);
            rewardPopUp.gameObject.SetActive(false);

            OnChestPopUpClosed?.Invoke();
            unlockNowButton.onClick.RemoveAllListeners();
            setTimerButton.onClick.RemoveAllListeners();
        }
        public void EnableSlotsFullPopUp()
        {
            chestSlotsFullPopUp.SetActive(true);
        }
        private void DisableSlotsFullPopUp()
        {
            chestSlotsFullPopUp.SetActive(false);
        }
        private void Start()
        {
            chestSlotsFullPopUp.SetActive(false);
            chestPopUp.SetActive(false);
            unlockNowButton.gameObject.SetActive(false);
            setTimerButton.gameObject.SetActive(false);
            rewardPopUp.gameObject.SetActive(false);

            //createChestButton.onClick.AddListener(ChestService.Instance.SpawnRandomChest);
            closeChestSlotsFull.onClick.AddListener(DisableSlotsFullPopUp);
            closeChestPopUp.onClick.AddListener(DisableChestPopUp);

            RefreshPlayerStats();
        }
    }
}