using UnityEngine;

public class PlayerBombView : MonoBehaviour
{
    [SerializeField] private GridForBomb _grid;

    [SerializeField] private GameObject _bombPrefab;
    [SerializeField] private int _maxAmount= 1;
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
        var finalPosition = _grid.GetNearestPointOnGrid(point);
        Instantiate(_bombPrefab, finalPosition, Quaternion.identity);
    }
}
