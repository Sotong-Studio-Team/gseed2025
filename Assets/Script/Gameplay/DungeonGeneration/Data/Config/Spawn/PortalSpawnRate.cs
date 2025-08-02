using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.DungeonGeneration.Data
{
    public interface IPortalSpawnRate : IDungeonSpawnRate
    {

    }

    [System.Serializable]
    public class PortalSpawnRate : DungeonObjectSpawnRate, IPortalSpawnRate
    {
        public PortalSpawnRate(string dungeonObjectId, ushort spawnRate) : base(dungeonObjectId, spawnRate)
        {
        }
    }
}
