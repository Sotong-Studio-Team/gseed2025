using System.Collections.Generic;
using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.DungeonGeneration.Data
{
    [CreateAssetMenu(fileName = "Dungeon Level Config", menuName = "Config/DungeonLevelConfig")]
    public class DungeonConfigSO : ScriptableObject
    {
        [SerializeField]
        private PortalSpawnRate[] _otherPortalSpawnRate;
        [SerializeField]
        private EnemySpawnRate _enemySpawnRate;
        [SerializeField]
        private DungeonObjectSpawnRate _coinSpawnRate;
        [SerializeField]
        private DungeonObjectSpawnRate _emptySpawnRate;


        [Header("Level Spawn Increase Weight")]
        
        public ushort IncreaseSapawnEnemy;
        public ushort IncreaseRateEnemy;
        [Space]
        public ushort IncreaseSapawnCoin;
        public ushort IncreaseRateCoin;
        [Space]
        public ushort IncreaseSapawnEmpty;
        public ushort IncreaseRateEmpty;

        public PortalSpawnRate[] OtherPortalSpawnRate { get
            {
                var listNewData = new List<PortalSpawnRate>();
                listNewData.AddRange(_otherPortalSpawnRate);
                return listNewData.ToArray();
            } 
        }
        public EnemySpawnRate EnemySpawnRate => new(_enemySpawnRate.DungeonObjectId,
                                                    _enemySpawnRate.SpawnRate,
                                                    _enemySpawnRate.EnemyUnits);
        public DungeonObjectSpawnRate CoinSpawnRate => new(_coinSpawnRate.DungeonObjectId,
                                                       _coinSpawnRate.SpawnRate);
        public DungeonObjectSpawnRate EmptySpawnRate => new(_emptySpawnRate.DungeonObjectId, 
                                                            _emptySpawnRate.SpawnRate);
    }
}
