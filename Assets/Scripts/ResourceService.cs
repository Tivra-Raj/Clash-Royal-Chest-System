using ChestSystem.Utilities;

namespace Assets.Scripts
{
    public class ResourceService : MonoSingletonGeneric<ResourceService>
    {
        private int gemsInAccount;
        private int coinsInAccount;

        private void Start()
        {
            gemsInAccount = 100;
            coinsInAccount = 200;
        }

        public int GetGemsInAccount() => gemsInAccount;
        
        public int GetCoinsInAccount() => coinsInAccount;
        
        public void IncrementGems(int gems)
        {
            gemsInAccount += gems;
            UIService.Instance.RefreshPlayerStats();
        }
        
        public void DecrementGems(int gems)
        {
            gemsInAccount -= gems;
            UIService.Instance.RefreshPlayerStats();
        }
        
        public void IncrementCoins(int coins)
        {
            coinsInAccount += coins;
            UIService.Instance.RefreshPlayerStats();
        }
        
        public void DecrementCoins(int coins)
        {
            coinsInAccount -= coins;
            UIService.Instance.RefreshPlayerStats();
        }
    }
}