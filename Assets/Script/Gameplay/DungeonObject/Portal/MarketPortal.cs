using SotongStudio.Bomber.Gameplay.Transition;
using VContainer;
using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.DungeonObject.Portal
{
    public class MarketPortal : PortalObject
    {
        private ITransitionController _transitionControl;
        [SerializeField]
        private bool _asReturn = false;

        [Inject]
        private void Inject(ITransitionController transitionControl)
        {
            _transitionControl = transitionControl;
        }
        public override void RecivePlayerInteractionProcess()
        {
            if (_asReturn)
            {
                _transitionControl.ReturnToMainMap();
            }
            else
            {
                _transitionControl.MoveToMarket();
                _transitionControl.SetReturnPos(transform.position);
            }
        }
    }
}
