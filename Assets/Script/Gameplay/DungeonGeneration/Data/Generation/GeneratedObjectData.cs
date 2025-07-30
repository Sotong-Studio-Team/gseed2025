using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.DungeonGeneration.Data
{
    public interface IGeneratedObjectData
    {
        string ObjectId { get; }
        bool IsCovered { get; }
        Vector2Int Coordinate { get; }
    }
    public class GeneratedObjectData : IGeneratedObjectData
    {
        public string ObjectId { get; private set; }
        public bool IsCovered { get; private set; }
        public Vector2Int Coordinate { get; private set; }

        public GeneratedObjectData(string objectId, bool isCovered, Vector2Int coordinate)
        {
            ObjectId = objectId;
            IsCovered = isCovered;
            Coordinate = coordinate;
        }
    }
}
