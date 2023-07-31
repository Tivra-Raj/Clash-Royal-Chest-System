using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChestMVC
{
    public class ChestView : MonoBehaviour
    {
        public ChestController ChestController { get; private set; }

        [SerializeField] private RectTransform chestRectTransform;
        [SerializeField] private Image chestImage;
        [SerializeField] private Button chestButton;
        [SerializeField] private TextMeshProUGUI topText;
        [SerializeField] private TextMeshProUGUI bottomText;

        public int TimeRemainingSeconds { get; private set; }

        public void SetChestController(ChestController chestController) => ChestController = chestController;

        public void SetChestAtSlot(ChestSlotController slot)
        {
            chestRectTransform.position = slot.GetSlotTransform().position;
        }

        private void Awake() => transform.SetParent(ChestService.Instance.ChestHolder);

        /*public void DestroyChest()
        {
            slot.SetIsEmpty(true);
            chestButton.onClick.RemoveAllListeners();
            chestController.RemoveView();
        }*/

        /*public IEnumerator CountDown()
        {
            while (TimeRemainingSeconds >= 0)
            {
                TimeSpan timeSpan = TimeSpan.FromSeconds(TimeRemainingSeconds);
                string timeString = timeSpan.ToString(@"hh\:mm\:ss");
                BottomText.text = timeString;

                TimeRemainingSeconds--;
                yield return new WaitForSeconds(1);
            }
            chestController.UnlockNow();
        }*/

        public void InitialSettings()
        {
            chestImage.sprite = ChestController.ChestModel.ChestClosedImage;
            //TimeRemainingSeconds = ChestController.ChestModel.UnlockDurationMinutes * 60;
            //chestButton.onClick.AddListener(chestController.ChestButtonAction);
        }
    }
}