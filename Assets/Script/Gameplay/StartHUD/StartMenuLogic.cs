using SotongStudio.Bomber.Gameplay.LevelManager;
using UnityEngine;
using VContainer.Unity;

namespace SotongStudio.Bomber
{
    public class StartMenuLogic : IInitializable
    {
        private readonly IStartMenuView _view;
        private readonly ILevelManager _levelManager;

        public StartMenuLogic(IStartMenuView view,
                              ILevelManager levelManager)
        {
            _view = view;
            _levelManager = levelManager;


            Debug.Log("Setup Start Menu");
        }

 
        void IInitializable.Initialize()
        {
            _view.OnStartMenu.AddListener(StartGame);
        }

        private void StartGame()
        {
            _levelManager.StartLevel();
        }
    }
}
