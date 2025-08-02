using SotongStudio.Bomber.Gameplay.Transition;
using UnityEngine;
using VContainer;

namespace SotongStudio.Bomber.Gameplay.DungeonObject.Portal
{
    public class AltarPortal : PortalObject
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
                _transitionControl.MoveToAltar();
                _transitionControl.SetReturnPos(transform.position);
            }
        }
    }
}
