using UnityEngine;

namespace SotongStudio.Bomber
{
    public interface IEnemyUnitSpawnRate
    {
        public string EnemyUnitId { get; }
        public ushort SpawnRate { get; }
    }

    [System.Serializable]
    public class EnemyUnitSpawnRate : IEnemyUnitSpawnRate
    {
        [field : SerializeField]
        public string EnemyUnitId { get; private set; }

        [field : SerializeField]
        public ushort SpawnRate { get; private set; }
        public EnemyUnitSpawnRate(string enemyUnitId, ushort spawnRate)
        {
            EnemyUnitId = enemyUnitId;
            SpawnRate = spawnRate;
        }
    }
}
