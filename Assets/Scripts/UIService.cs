using ChestMVC;
using ChestStates;
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
        public Button StartUnlockButton { get { return startUnlockButton; } private set { } }

        public Button CloseRewardPopUP { get { return closeRewardPopUP; } private set { } }
        public TextMeshProUGUI GiftCoinText { get { return giftCoinText; } private set { } }
        public TextMeshProUGUI GiftGemText { get { return giftGemText; } private set { } }

        public TextMeshProUGUI UnlockText { get { return unlockText; } private set { } }

        [Header("Create Chest Button")]
        [SerializeField] private Button createChestButton;

        [Header("Chest Slot Pop Up")]
        [SerializeField] private GameObject chestSlotsFullPopUp;
        [SerializeField] private Button closeChestSlotsFull;

        [Header("Chest Pop Up")]
        [SerializeField] private GameObject chestPopUp;
        [SerializeField] private Button closeChestPopUp;
        [SerializeField] private Button startUnlockButton;
        [SerializeField] private Button unlockNowButton;     
        [SerializeField] private TextMeshProUGUI unlockText;

        [Header("Rewards Pop Up")]
        [SerializeField] private GameObject rewardPopUp;
        [SerializeField] private Button closeRewardPopUP;
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

        public void EnableRewardPopUp()
        {
            rewardPopUp.SetActive(true);
        }

        public void DisableChestPopUp()
        {
            chestPopUp.SetActive(false);
            rewardPopUp.gameObject.SetActive(false);

            OnChestPopUpClosed?.Invoke();
            unlockNowButton.onClick.RemoveAllListeners();
            startUnlockButton.onClick.RemoveAllListeners();
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
            rewardPopUp.gameObject.SetActive(false);

            createChestButton.onClick.AddListener(ChestService.Instance.SpawnRandomChest);
            closeChestSlotsFull.onClick.AddListener(DisableSlotsFullPopUp);
            closeChestPopUp.onClick.AddListener(DisableChestPopUp);

            RefreshPlayerStats();
        }

        private void Update()
        {
            CloseRewardPopUP.onClick.AddListener(DisableRewardPopUp);
        }

        public void DisableRewardPopUp()
        {
            ChestService.Instance.ChestController.DestroyChest();
            rewardPopUp.SetActive(false);
        }
    }
}