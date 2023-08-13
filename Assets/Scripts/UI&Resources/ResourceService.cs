using Utilities;
using UnityEngine;

namespace UIandResources
{
    public class ResourceService : MonoSingletonGeneric<ResourceService>
    {
        [SerializeField] private int coins;
        [SerializeField] private int gems;

        public int GetGems() => gems;
        
        public int GetCoins() => coins;
        
        public void IncrementGems(int gemsToAdd)
        {
            gems += gemsToAdd;
            UIService.Instance.RefreshPlayerStats();
        }
        
        public void DecrementGems(int gemsRequired)
        {
            gems -= gemsRequired;
            UIService.Instance.RefreshPlayerStats();
        }
        
        public void IncrementCoins(int coinsToAdd)
        {
            coins += coinsToAdd;
            UIService.Instance.RefreshPlayerStats();
        }
        
    }
}