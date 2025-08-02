using SotongStudio.Bomber.Gameplay.HUD;
using SotongStudio.Bomber.Gameplay.LevelManager;
using VContainer.Unity;

namespace SotongStudio.Bomber.Gameplay
{
    public class MainGameFlowControl : IPostStartable
    {
        private readonly ILevelManager _levelManager;
        private readonly IGameplayHudLogic _gamePlayHudLogic;

        public MainGameFlowControl(ILevelManager levelManager,
                                    IGameplayHudLogic hudLogic)
        {
            _levelManager = levelManager;
            _gamePlayHudLogic = hudLogic;
        }

        public void PostStart()
        {
            _gamePlayHudLogic.UpdateHealth();
            _gamePlayHudLogic.UpdateBomb();
            _gamePlayHudLogic.UpdateCrystal();
        }
    }
}
