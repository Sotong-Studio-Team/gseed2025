using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[System.Serializable]
public class GridVisualizer
{
    [SerializeField] private Vector2Int _gridSize = new Vector2Int(5, 5);
    [SerializeField] private List<Vector2Int> _activeCells = new List<Vector2Int>();

    public List<Vector2Int> GetActiveCells() => _activeCells;

    public Vector2Int GridSize
    {
        get => _gridSize;
        set
        {
            _gridSize = new Vector2Int(
                Mathf.Max(1, value.x),
                Mathf.Max(1, value.y)
            );
            ValidateCells();
        }
    }

    private void ValidateCells()
    {
        Vector2Int halfSize = _gridSize / 2;
        _activeCells.RemoveAll(cell =>
            Mathf.Abs(cell.x) > halfSize.x ||
            Mathf.Abs(cell.y) > halfSize.y);
    }

    public void ToggleCell(Vector2Int gridPos)
    {
        if (_activeCells.Contains(gridPos))
            _activeCells.Remove(gridPos);
        else
            _activeCells.Add(gridPos);
    }

    public void UpdateTargetArray(ref Vector2Int[] targetArray)
    {
        targetArray = _activeCells.ToArray();
    }

    public RectInt GetGridBounds()
    {
        Vector2Int halfSize = _gridSize / 2;
        return new RectInt(
            -halfSize.x,
            -halfSize.y,
            _gridSize.x,
            _gridSize.y
        );
    }

}