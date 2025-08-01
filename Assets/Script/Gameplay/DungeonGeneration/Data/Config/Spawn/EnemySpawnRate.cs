using System.Collections.Generic;
using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.DungeonGeneration.Data
{
    public interface IEnemySpawnRate : IDungeonSpawnRate
    {
        List<EnemyUnitSpawnRate> EnemyUnits { get; }
    }

    [System.Serializable]
    public class EnemySpawnRate : DungeonObjectSpawnRate, IEnemySpawnRate
    {

        [field:SerializeField]
        public List<EnemyUnitSpawnRate> EnemyUnits { get; private set; }


        public EnemySpawnRate(string dungeonObjectId, ushort spawnRate, List<EnemyUnitSpawnRate> enemyUnitSpawnRate) : base(dungeonObjectId, spawnRate)
        {
            EnemyUnits = enemyUnitSpawnRate;
        }
    }
}
