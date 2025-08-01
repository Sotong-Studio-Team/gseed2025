using SotongStudio.Bomber.Gameplay.LevelManager;
using UnityEngine;

namespace SotongStudio.Bomber
{
    public class StartMenuLogic 
    {
        private readonly IStartMenuView _view;
        private readonly ILevelManager _levelManager;

        public StartMenuLogic(IStartMenuView view,
                              ILevelManager levelManager)
        {
            _view = view;
            _levelManager = levelManager;

            _view.OnStartMenu.AddListener(StartGame);

            Debug.Log("Setup Start Menu");
        }

        private void StartGame()
        {
            _levelManager.StartLevel(1);
        }
    }
}
