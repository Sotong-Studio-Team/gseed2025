using UnityEngine;

namespace SotongStudio.Utilities.Vector2Helper
{
    public static class WorldSnappingPos
    {
        public static Vector2 SnapWorldPosition(Vector3 worldPosition, float snapingSize = 1)
        {
            int xCount = Mathf.RoundToInt(worldPosition.x / snapingSize);
            int yCount = Mathf.RoundToInt(worldPosition.y / snapingSize);

            Vector3 result = new Vector2(xCount * snapingSize,
                                         yCount * snapingSize);

            return result;
        }
    }
}
