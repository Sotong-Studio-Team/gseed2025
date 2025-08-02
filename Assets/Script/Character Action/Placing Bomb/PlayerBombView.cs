using System.Collections;
using SotongStudio.Bomber.Gameplay.Bomb;
using SotongStudio.Bomber.Gameplay.Character.DataService;
using SotongStudio.Bomber.Gameplay.Character;
using SotongStudio.Bomber.Gameplay.Inventory;
using SotongStudio.Utilities.Vector2Helper;
using UnityEngine;
using UnityEngine.Events;
using VContainer;
using SotongStudio.Bomber.Gameplay.Bomb.Data;

public class PlayerBombView : MonoBehaviour
{
    //[SerializeField] private GridForBomb _grid;

    private ICharacterGameplayDataService _characterDataService;
    private ICharacterGameplayUpdateService _characterDataUpdate;
    private IBombGameplayDataService _bombDataService;

    [Inject]
    public void Inject(ICharacterGameplayDataService characterDataService, ICharacterGameplayUpdateService characterDataUpdate, 
                       IBombGameplayDataService bombDataService)
    {
        _characterDataService = characterDataService;
        _characterDataUpdate = characterDataUpdate;

        _bombDataService = bombDataService;
    }

    [SerializeField] private GameObject _bombPrefab;
    [SerializeField] private Transform _bombPlacement;

    public UnityEvent OnBombDeployed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _characterDataService.GetBombAmount() > 0)
        {
            _characterDataUpdate.ReduceBombAmount(1);
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
        yield return new WaitForSeconds(_bombDataService.GetBombUseCooldown());
        _characterDataUpdate.AddBombAmount(1);
    }
}
