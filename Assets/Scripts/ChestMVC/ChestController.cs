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
    }
}