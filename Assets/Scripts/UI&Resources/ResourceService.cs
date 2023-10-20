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
            Debug.Log("Increment Gems");
            Debug.Log($"IncrementGems - {gems} + {gemsToAdd} = {gems + gemsToAdd}");
            gems += gemsToAdd;
            
            UIService.Instance.RefreshPlayerStats();
        }
        
        public void DecrementGems(int gemsRequired)
        {
            Debug.Log(gemsRequired);
            gems -= gemsRequired;
            UIService.Instance.RefreshPlayerStats();
        }
        
        public void IncrementCoins(int coinsToAdd)
        {
            Debug.Log($"IncrementCoins - {coins} + {coinsToAdd} = {coins + coinsToAdd}");
            coins += coinsToAdd;
            UIService.Instance.RefreshPlayerStats();
        }
        
    }
}