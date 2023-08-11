using ChestMVC;
using UnityEngine;

namespace ChestStates
{
    public class ChestState : MonoBehaviour
    {
        [SerializeField] protected ChestView chestPrefab;

        public virtual void OnStateEnter()
        {
            this.enabled = true;
        }

        public virtual void OnStateExit()
        {
            this.enabled = false;
        }

        public virtual void OnChestButtonAction()
        {
            this.enabled = true;
        }

        public void ChangeChestState(ChestState newState)
        {
            if (chestPrefab.chestCurrentState != null)
            {
                chestPrefab.chestCurrentState.OnStateExit();
            }

            chestPrefab.chestCurrentState = newState;
            chestPrefab.chestCurrentState.OnStateEnter();
        }
    }
}