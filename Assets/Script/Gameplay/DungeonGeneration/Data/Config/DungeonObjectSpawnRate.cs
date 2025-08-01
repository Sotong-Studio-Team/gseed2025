using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.DungeonGeneration.Data
{
    public interface IDungeonSpawnRate
    {
        string DungeonObjectId { get; }

        ushort SpawnRate { get; }

        void AddWeight(ushort weight);
    }

    [System.Serializable]
    public class DungeonObjectSpawnRate : IDungeonSpawnRate
    {
        public DungeonObjectSpawnRate(string dungeonObjectId, ushort spawnRate)
        {
            DungeonObjectId = dungeonObjectId;
            SpawnRate = spawnRate;
        }

        [field: SerializeField]
        public string DungeonObjectId { get; private set; }
        [field: SerializeField]
        public ushort SpawnRate { get; private set; }

        public void AddWeight(ushort weight)
        {
            SpawnRate += weight;
        }
    }
}
