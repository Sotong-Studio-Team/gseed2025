using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBombView : MonoBehaviour
{
    [SerializeField] private GridForBomb _grid;

    [SerializeField] private GameObject _bombPrefab;
    [SerializeField] private int _maxAmount= 1;
    [SerializeField] private float _bombCooldown = 1.5f;
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
        var finalPosition = _grid.GetNearestPointOnGrid(point);
        Instantiate(_bombPrefab, finalPosition, Quaternion.identity);
    }

    IEnumerator BombCooldownCo()
    {
        yield return new WaitForSeconds(_bombCooldown);
        _currentAmount++;
    }
}
