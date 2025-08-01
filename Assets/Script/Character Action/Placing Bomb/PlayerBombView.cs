using SotongStudio.Utilities.Vector2Helper;
using UnityEngine;

public class PlayerBombView : MonoBehaviour
{
    //[SerializeField] private GridForBomb _grid;

    [SerializeField] private GameObject _bombPrefab;
    [SerializeField] private int _maxAmount= 1;
    [SerializeField] private Transform _bombPlacement;
    private int _currentAmount;

    private void Start()
    {
        _currentAmount = _maxAmount;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _currentAmount > 0)
        {
            _currentAmount--;
            PlaceBomb(transform.position);
        }
    }

    private void PlaceBomb(Vector2 point)
    {
        var finalPosition = WorldSnappingPos.SnapWorldPosition(point);
            //_grid.GetNearestPointOnGrid(point);
        var createdBomb = Instantiate(_bombPrefab, finalPosition, Quaternion.identity);
        createdBomb.transform.parent = _bombPlacement;
    }
}
