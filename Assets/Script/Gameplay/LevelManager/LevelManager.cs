using SotongStudio.Bomber.Gameplay.DungeonGeneration.Data;
using SotongStudio.Bomber.Gameplay.DungeonGeneration.Service;
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

        public UnityEvent<int> OnChangeLevel { get; private set; } = new();
        private int _currentLevel = 0;


        public LevelManager(IDungeonGenerationService generationService,
                            LevelManagerData levelManagerData,
                            PlayerMovementLogic playerLogic
            )
        {
            _generationService = generationService;
            _levelManagerData = levelManagerData;
            _playerLogic = playerLogic;
        }

        public void StartLevel()
        {
            _currentLevel++;
            OnChangeLevel?.Invoke(_currentLevel);

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
