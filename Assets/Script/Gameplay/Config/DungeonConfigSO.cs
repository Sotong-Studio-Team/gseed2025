using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.DungeonGeneration.Data
{
    [CreateAssetMenu(fileName = "Dungeon Level Config", menuName = "Config/DungeonLevelConfig")]
    public class DungeonConfigSO : ScriptableObject
    {
        public PortalSpawnRate[] OtherPortalSpawnRate;
        public EnemySpawnRate EnemySpawnRate;
        public DungeonObjectSpawnRate CoinSpawnRate;
        public DungeonObjectSpawnRate EmptySpawnRate;
    }
}
