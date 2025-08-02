using SotongStudio.Bomber.Gameplay.Transition;
using VContainer;

namespace SotongStudio.Bomber.Gameplay.DungeonObject.Portal
{
    public interface INextLevelPortal : IPortalObject
    {
        
    }   
    public class NextLevelPortal : PortalObject, INextLevelPortal
    {
        private ITransitionController _transitionController;

        [Inject]
        private void Inject(ITransitionController transitionController)
        {
            _transitionController = transitionController;
        }

        public override void RecivePlayerInteractionProcess()
        {
            _transitionController.MoveToNextLevel();
        }


    }
}
