using ChestMVC;
using ChestSlot;
using ChestStates;
using Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIandResources
{
    public class UIService : MonoSingletonGeneric<UIService>
    {
        public TextMeshProUGUI RewardCoinText { get { return rewardCoinText; } private set { } }
        public TextMeshProUGUI RewardGemText { get { return rewardGemText; } private set { } }

        [Header("Create Chest Button")]
        [SerializeField] private Button createChestButton;

        [Header("Chest Slot Pop Up")]
        [SerializeField] private GameObject chestSlotsFullPopUp;
        [SerializeField] private Button closeChestSlotsFull;

        [Header("Insufficiant Resource Pop Up")]
        [SerializeField] private GameObject insufficiantResourcePopUp;
        [SerializeField] private Button closeInsufficiantResourcePopUp;

        [Header("Chest Pop Up")]
        [SerializeField] private GameObject chestPopUp;
        [SerializeField] private Button closeChestPopUp;
        [SerializeField] private Button startUnlockButton;
        [SerializeField] private Image startUnlockBackgroundImage;
        [SerializeField] private TextMeshProUGUI startUnlockText;
        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private Button unlockNowButton;     
        [SerializeField] private TextMeshProUGUI unlockNowGemText;
        [SerializeField] private GameObject unlockingChestPopUp;

        [Header("Rewards Pop Up")]
        [SerializeField] private GameObject rewardPopUp;
        [SerializeField] private Button closeRewardPopUP;
        [SerializeField] private TextMeshProUGUI rewardCoinText;
        [SerializeField] private TextMeshProUGUI rewardGemText;

        [Header("Player Stats")]
        [SerializeField] private TextMeshProUGUI coins;
        [SerializeField] private TextMeshProUGUI gems;

        private void Start()
        {
            chestSlotsFullPopUp.SetActive(false);
            insufficiantResourcePopUp.SetActive(false);
            chestPopUp.SetActive(false);
            unlockingChestPopUp.SetActive(false);
            rewardPopUp.gameObject.SetActive(false);

            createChestButton.onClick.AddListener(ChestService.Instance.SpawnChest);

            closeChestSlotsFull.onClick.AddListener(DisableSlotsFullPopUp);
            closeInsufficiantResourcePopUp.onClick.AddListener(DisableInsufficiantResourcePopUp);
            closeChestPopUp.onClick.AddListener(DisableChestPopUp);
            closeRewardPopUP.onClick.AddListener(DisableRewardPopUp);

            RefreshPlayerStats();
        }

        public void RefreshPlayerStats()
        {
            coins.text = ResourceService.Instance.GetCoins().ToString();
            gems.text = ResourceService.Instance.GetGems().ToString();
        }

        public void EnableSlotsFullPopUp()
        {
            chestSlotsFullPopUp.SetActive(true);
        }
        private void DisableSlotsFullPopUp()
        {
            chestSlotsFullPopUp.SetActive(false);
        }

        public void EnableInsufficiantResourcePopUp()
        {
            insufficiantResourcePopUp.SetActive(true);
        }
        private void DisableInsufficiantResourcePopUp()
        {
            insufficiantResourcePopUp.SetActive(false);
        }


        public void OnChestClicked(ChestStateEnum chestState, GameObject SelectedChest)
        {
            if (chestState == ChestStateEnum.Locked)
            {
                ChestLockedStatePopUp(chestState, SelectedChest);
            }
            else if (chestState == ChestStateEnum.Unlocking)
            {
                ChestUnlockingStatePopUp(chestState, SelectedChest);
            }
            else if (chestState == ChestStateEnum.Unlocked)
            {
                ChestUnlockedStatePopUp(SelectedChest);
            }
        }

        public void OnStartUnlockButtonClick(GameObject SelectedChest)
        {
            ChestService.Instance.OnStartUnlocking(SelectedChest);
        }

        public void OnUnlockNowButtonClick(GameObject selectedChest)
        {
            ChestService.Instance.OnUnlockNowChest(selectedChest);
        }

        private void ChestLockedStatePopUp(ChestStateEnum chestState, GameObject chestObject)
        {
            EnableChestPopUp(chestState);
            startUnlockButton.onClick.AddListener(() => OnStartUnlockButtonClick(chestObject));
            unlockNowButton.onClick.AddListener(() => OnUnlockNowButtonClick(chestObject));
        }

        private void ChestUnlockingStatePopUp(ChestStateEnum chestState, GameObject chestObject)
        {
            EnableChestPopUp(chestState);
        }

        private void ChestUnlockedStatePopUp(GameObject chestObject)
        {
            ChestService.Instance.GiveRewards();
            EnableRewardPopUp();
        }

        public void EnableChestPopUp(ChestStateEnum chestState)
        {
            chestPopUp.SetActive(true);
            if (chestState == ChestStateEnum.Locked)
            {
                unlockingChestPopUp.SetActive(false);
                startUnlockBackgroundImage.gameObject.SetActive(false);
                if (ChestSlotService.Instance.IsChestUnlocking == true)
                {
                    startUnlockButton.gameObject.SetActive(true);
                    startUnlockBackgroundImage.gameObject.SetActive(true);
                    startUnlockButton.enabled = false;
                    startUnlockText.text = "Another Unlock is still in progress!";
                    timerText.gameObject.SetActive(false);
                }            
            }
            else if(chestState == ChestStateEnum.Unlocking)
            {
                startUnlockButton.gameObject.SetActive(false);
                unlockingChestPopUp.SetActive(true);
            }
        }

        public void DisableChestPopUp()
        {
            chestPopUp.SetActive(false);
            rewardPopUp.gameObject.SetActive(false);

            unlockNowButton.onClick.RemoveAllListeners();
            startUnlockButton.onClick.RemoveAllListeners();
        }

        public void EnableRewardPopUp()
        {
            rewardPopUp.SetActive(true);
        }

        public void DisableRewardPopUp()
        {
            rewardPopUp.SetActive(false);
        }
    }
}