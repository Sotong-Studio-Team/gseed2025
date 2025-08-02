using System.Collections;
using SotongStudio.Utilities.Vector2Helper;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBombView : MonoBehaviour
{
    //[SerializeField] private GridForBomb _grid;

    [SerializeField] private GameObject _bombPrefab;
    [SerializeField] private int _maxAmount= 1;
    [SerializeField] private float _bombCooldown = 1.5f;
    [SerializeField] private Transform _bombPlacement;
    private int _currentAmount;

    public UnityEvent OnBombDeployed;

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
            StartCoroutine(BombCooldownCo());
        }
    }

    private void PlaceBomb(Vector2 point)
    {
        var finalPosition = WorldSnappingPos.SnapWorldPosition(point) - (Vector2.up/2);
            //_grid.GetNearestPointOnGrid(point);
        var createdBomb = Instantiate(_bombPrefab, finalPosition, Quaternion.identity);
        createdBomb.transform.parent = _bombPlacement;
    }

    IEnumerator BombCooldownCo()
    {
        yield return new WaitForSeconds(_bombCooldown);
        _currentAmount++;
    }
}
