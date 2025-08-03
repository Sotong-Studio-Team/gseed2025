using SotongStudio.Bomber.Gameplay.DungeonGeneration.Data;
using SotongStudio.Bomber.Gameplay.DungeonGeneration.Service;
using SotongStudio.Bomber.Gameplay.HUD;
using UnityEngine.Events;

namespace SotongStudio.Bomber.Gameplay.LevelManager
{
    public interface ILevelManager
    {
        void StartLevel();
        UnityEvent<int> OnChangeLevel { get; }
        int GetCurrentLevel();
    }

    public class LevelManager : ILevelManager
    {
        private readonly IDungeonGenerationService _generationService;
        private readonly LevelManagerData _levelManagerData;
        private readonly PlayerMovementLogic _playerLogic;
        private readonly IGameplayHudLogic _hudLogic;

        public UnityEvent<int> OnChangeLevel { get; private set; } = new();
        private int _currentLevel = 0;


        public LevelManager(IDungeonGenerationService generationService,
                            LevelManagerData levelManagerData,
                            PlayerMovementLogic playerLogic,
                            IGameplayHudLogic hudLogic
            )
        {
            _generationService = generationService;
            _levelManagerData = levelManagerData;
            _playerLogic = playerLogic;
            _hudLogic = hudLogic;
        }

        public void StartLevel()
        {
            _currentLevel++;
            OnChangeLevel?.Invoke(_currentLevel);

            _hudLogic.UpdateLevel(_currentLevel);

            var startDungeonConfig = DungeonConfig.CretaeDungeonData(_levelManagerData.DungeonConfigSO, _currentLevel);
            _generationService.GenerateDungeon(startDungeonConfig);

            ResetToStart();
        }

        private void ResetToStart()
        {
            var startPos = _generationService.GetPlayerStartPos();
            _playerLogic.TeleportPlayer(startPos);
        }

        public int GetCurrentLevel()
        {
            return _currentLevel;
        }   
    }
}
