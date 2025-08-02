using UnityEngine;

namespace SotongStudio.Bomber
{
    public class MarketInteractionComponent : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private MarketView _view;

        public void Interact()
        {
            _view.ShowUI();
        }
    }
}
