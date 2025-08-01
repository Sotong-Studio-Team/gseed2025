using SotongStudio.Bomber.Gameplay.LevelManager;
using VContainer;

namespace SotongStudio.Bomber.Gameplay.DungeonObject.Portal
{
    public interface INextLevelPortal : IPortalObject
    {
        
    }   
    public class NextLevelPortal : PortalObject, INextLevelPortal
    {
        private ILevelManager _levelManager;

        [Inject]
        private void Inject(ILevelManager levelManager)
        {
            _levelManager = levelManager;
        }

        public override void RecivePlayerInteractionProcess()
        {
            _levelManager.StartLevel();
        }


    }
}
