using Assets.Scripts.ChestMVC.ChestStates;

namespace ChestMVC
{
    public class ChestController
    {
        public ChestModel ChestModel { get; private set; }
        public ChestView ChestView { get; private set; }

        private ChestStateMachine chestStateMachine;

        public ChestController(ChestModel chestModel, ChestView chestView)
        {
            ChestModel = chestModel;
            ChestView = chestView;
            chestStateMachine = new ChestStateMachine();
        }

        public ChestStateMachine GetChestStateMachine() => chestStateMachine;

        public void SetChestView()
        {
            ChestView.chestImage.sprite = ChestModel.ChestClosedImage;
            ChestView.chestCurrentState = ChestView.chestLockedState;
            ChestView.InitializeChestState();
        }

        /*
            Method is executed whenever Chest is Clicked. Triggers the Popup.
            Uses ChestService to contact PopupService. 
        */

        /*public void OnChestButtonClicked()
        {
            ChestService.Instance.TriggerPopUp(this);
        }*/
    }
}