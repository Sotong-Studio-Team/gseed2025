using SotongStudio.Bomber.Gameplay.Inventory;
using SotongStudio.Bomber.Gameplay.LevelManager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SotongStudio.Bomber
{
    public interface IGameOverHUDLogic
    {
        void Show();
    }
    public class GameOverHUDLogic : IGameOverHUDLogic
    {
        private readonly IGameOverHUDView _view;
        private readonly IInventoryGameplayDataService _inventoryService;
        private readonly ILevelManager _levelManager;

        public GameOverHUDLogic(IGameOverHUDView view,
                                IInventoryGameplayDataService inventoryService,
                                ILevelManager levelManager)
        {
            _view = view;
            _view.OnPlayAgain.AddListener(PlayAgainProcess);

            _inventoryService = inventoryService;
            _levelManager = levelManager;
        }

        public void Show()
        {
            _view.SetCrystalCount(_inventoryService.GetRcordedCrystal());
            _view.SetClearAmount(_levelManager.GetCurrentLevel());
            _view.Show();
        }

        private void PlayAgainProcess()
        {
            Time.timeScale = 1f; // Resume the game time
            SceneManager.LoadScene("Game Main");
        }
    }
}
