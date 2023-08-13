using UnityEngine;

namespace scriptableObject
{
    [CreateAssetMenu(fileName = "NewChest SO Holder ", menuName = "SriptableObjects/CreateNewChestSO Holder")]
    public class ChestScriptableObjectList : ScriptableObject
    {
        public ChestScriptableObject[] chestScriptableObjects; 
    }
}