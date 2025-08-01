using NaughtyAttributes;
using SotongStudio.Bomber.Gameplay.DungeonGeneration.Data;
using SotongStudio.Bomber.Gameplay.DungeonGeneration.Service;
using SotongStudio.Bomber.Gameplay.DungeonObject;
using UnityEngine;
using VContainer;

namespace SotongStudio.Bomber
{
    public class DungeonGenerationTest : MonoBehaviour
    {
        private IDungeonGenerationService _genrateService;

        [SerializeField]
        private DungeonConfigSO _dungeonConfig;

        [Inject]
        public void Inject(IDungeonGenerationService generationService)
        {
            _genrateService = generationService;
        }


        [Button]
        private void GenerateDungeonData()
        {
            var config = DungeonConfig.CretaeDungeonData(_dungeonConfig);
            _genrateService.GenerateDungeon(config);
        }

        [Button]
        private void DestroyAllSoft()
        {
            var allSoftWalls = Object.FindObjectsByType<DungeonObject>(FindObjectsSortMode.None);
            foreach (var wall in allSoftWalls)
            {
                wall.TakeExplosionDamageProcess(1000);
            }
        }
    }
}
