using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class GridVisualizer
{
    [SerializeField]
    private Vector2Int _gridSize;

    [SerializeField]
    private List<Vector2Int> _activeCells;

    [SerializeField]
    private List<Vector2Int> _nonActiveCells;

    public List<Vector2Int> GetActiveCells() => _activeCells;
    public List<Vector2Int> GetNonActiveCells() => _nonActiveCells;

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
        {
            _activeCells.Remove(gridPos);
        }
        else
        {
            _activeCells.Add(gridPos);
        }

        UpdateNonActiveCells();
    }

    private void UpdateNonActiveCells()
    {
        List<Vector2Int> allCoordinate = new();
        var bounds = GetGridBounds();

        for (int x = 0; x < _gridSize.x; x++)
        {
            for (int y = 0; y < _gridSize.y; y++)
            {
                Vector2Int cellPos = new Vector2Int(
                bounds.xMin + x,
                    bounds.yMin + y
                );
                allCoordinate.Add(cellPos);
            }
        }

        _nonActiveCells = allCoordinate.Except(_activeCells)
                            .ToList();
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