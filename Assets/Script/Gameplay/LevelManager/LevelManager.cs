using SotongStudio.Bomber.Gameplay.DungeonGeneration.Data;
using SotongStudio.Bomber.Gameplay.DungeonGeneration.Service;
using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.LevelManager
{
    public interface ILevelManager
    {
        void StartLevel(int level);
    }

    public class LevelManager : ILevelManager
    {
        private readonly IDungeonGenerationService _generationService;
        private readonly IDungeonConfig _startDungeonConfig;

        public LevelManager(IDungeonGenerationService generationService,
                            LevelManagerData levelManagerData
            )
        {
            _generationService = generationService;
            _startDungeonConfig = DungeonConfig.CretaeDungeonData(levelManagerData.DungeonConfigSO);
        }

        public void StartLevel(int level)
        {
            _generationService.GenerateDungeon(_startDungeonConfig);
        }
    }
}
