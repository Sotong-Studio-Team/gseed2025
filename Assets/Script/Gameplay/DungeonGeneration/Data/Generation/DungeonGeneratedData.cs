using System.Collections.Generic;

namespace SotongStudio.Bomber.Gameplay.DungeonGeneration.Data
{
    public interface IDugeonGeneratedData
    {
        IEnumerable<IGeneratedObjectData> GeneratedObjects { get; }
        IEnumerable<IGeneratedClusterData> GeneratedClusters { get; }
    }
    public class DungeonGeneratedData : IDugeonGeneratedData
    {
        public IEnumerable<IGeneratedObjectData> GeneratedObjects { get; private set; }
        public IEnumerable<IGeneratedClusterData> GeneratedClusters {get; private set;}

        public DungeonGeneratedData(IEnumerable<IGeneratedObjectData> generatedObjects, IEnumerable<IGeneratedClusterData> generatedClusters)
        {
            GeneratedObjects = generatedObjects;
            GeneratedClusters = generatedClusters;
        }
    }
}
