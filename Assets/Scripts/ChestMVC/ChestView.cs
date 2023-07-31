using UnityEngine;

namespace ChestMVC
{
    public class ChestView : MonoBehaviour
    {
        public ChestController ChestController { get; private set; }

        public void SetChestController(ChestController chestController) => ChestController = chestController;
    }
}