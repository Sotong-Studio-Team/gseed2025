using SotongStudio.Bomber.Gameplay.DungeonGeneration.Service;
using SotongStudio.Bomber.Gameplay.LevelManager;
using VContainer.Unity;

namespace SotongStudio.Bomber.Gameplay
{
    public class MainGameFlowControl : IInitializable 
    {
        private readonly ILevelManager _levelManager;

        public MainGameFlowControl(ILevelManager levelManager)
        {
            _levelManager = levelManager;
        }

        void IInitializable.Initialize()
        {
            _levelManager.StartLevel(1);
        }
    }
}
