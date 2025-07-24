using UnityEngine;

namespace SotongStudio.Unlink.Utilities.Vector2Helper
{
    public static class Vector2Helper
    {
        public static Vector2 AsVerticalHorizontalOnly(this Vector2 inputValue)
        {
            if (inputValue.x != 0 && inputValue.y != 0)
            {
                return Vector2.zero;
            }
            return inputValue;
        }
    }
}
