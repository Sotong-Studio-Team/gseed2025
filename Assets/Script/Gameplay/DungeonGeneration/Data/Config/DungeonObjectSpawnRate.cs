using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.DungeonGeneration.Data
{
    public interface IDungeonSpawnRate
    {
        string DungeonObjectId { get; }

        ushort SpawnRate { get; }
    }

    [System.Serializable]
    public class DungeonObjectSpawnRate : IDungeonSpawnRate
    {
        [field: SerializeField]
        public string DungeonObjectId { get; private set; }
        [field: SerializeField]
        public ushort SpawnRate {get; private set;}
    }
}
