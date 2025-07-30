using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace SotongStudio
{
    public class GridVisualizerTest : MonoBehaviour
    {
        [SerializeField]
        private Vector2Int[] _targetArray;

        [SerializeField]
        private GridVisualizer _grid = new();

        [Button]
        private void UpdateTargetArray()
        {
            _targetArray = _grid.GetActiveCells().ToArray();
            Debug.Log($"Updated array with {_targetArray.Length} elements:");

            foreach (var pos in _targetArray)
            {
                Debug.Log(pos);
            }
        }
    }
}
