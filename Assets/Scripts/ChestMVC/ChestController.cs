using UnityEngine;

namespace ChestMVC
{
    public class ChestController
    {
        public ChestModel ChestModel { get; private set; }
        public ChestView ChestView { get; private set; }

        public ChestController(ChestModel chestModel, ChestView chestView)
        {
            ChestModel = chestModel;
            ChestView = GameObject.Instantiate<ChestView>(chestView);

            ChestModel.SetChestController(this);
            ChestView.SetChestController(this);
        }

        public void Configure(RectTransform transform)
        {
            ChestView.transform.position = transform.position;
        }

        public void UnlockNow()
        {
            /*PlayerService.Instance.DecrementGems(currentState.GetRequiredGemsToUnlock());

            currentState.OnStateDisable();
            currentState = chestUnlocked;
            currentState.OnStateEnable();*/
        }
        public void StartUnlocking()
        {
            /*currentState.OnStateDisable();
            currentState = chestUnlocking;
            currentState.OnStateEnable();*/
        }

        public void DestroyChest()
        {
            ChestView.chestSlotController.SetSlotIsEmpty(true);
            ChestView.gameObject.SetActive(false);
            ChestService.Instance.ReturnChestToPool(this);
        }
    }
}