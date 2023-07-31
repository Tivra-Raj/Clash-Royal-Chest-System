using ChestSystem.Utilities;

namespace ChestMVC
{
    public class ChestPool : GenericObjectPool<ChestController>
    {
        private ChestView chestPrefab;
        private ChestModel chestData;

        public ChestController GetChest(ChestModel chestdata, ChestView chestPrefab)
        {  
            this.chestPrefab = chestPrefab;
            this.chestData = chestdata;

            ChestController chestController = GetItem();
            chestController.ChestView.gameObject.SetActive(true);
            return chestController;
        }

        protected override ChestController CreateItem() => new ChestController(chestData, chestPrefab);
    }
}