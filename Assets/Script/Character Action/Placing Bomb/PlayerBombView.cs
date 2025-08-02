using System.Collections;
using SotongStudio.Bomber.Gameplay.Bomb;
using SotongStudio.Bomber.Gameplay.Character.DataService;
using SotongStudio.Bomber.Gameplay.HUD;
using SotongStudio.Utilities.Vector2Helper;
using UnityEngine;
using UnityEngine.Events;
using VContainer;
using SotongStudio.Utilities.AudioSystem;

public class PlayerBombView : MonoBehaviour
{
    //[SerializeField] private GridForBomb _grid;

    private ICharacterGameplayDataService _characterDataService;
    private ICharacterGameplayUpdateService _characterDataUpdate;
    private IGameplayHudLogic _hudLogic;
    private IBombGameplayDataService _bombDataService;

    [Inject]
    public void Inject(ICharacterGameplayDataService characterDataService,
                       ICharacterGameplayUpdateService characterDataUpdate,
                       IBombGameplayDataService bombDataService,
                       IGameplayHudLogic hudLogic)
    {
        _characterDataService = characterDataService;
        _bombDataService = bombDataService;
        _characterDataUpdate = characterDataUpdate;

        _hudLogic = hudLogic;

    }

    [SerializeField] private GameObject _bombPrefab;
    [SerializeField] private Transform _bombPlacement;

    public UnityEvent OnBombDeployed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _characterDataService.GetBombAmount() > 0)
        {
            BasicAudioSystem.Instance.PlaySFX("throwing");
            _characterDataUpdate.ReduceBombAmount(1);
            _hudLogic.UpdateBomb();
            PlaceBomb(transform.position);
            StartCoroutine(BombCooldownCo());
        }
    }

    private void PlaceBomb(Vector2 point)
    {
        var finalPosition = WorldSnappingPos.SnapWorldPosition(point + (Vector2.up/2));
        //_grid.GetNearestPointOnGrid(point);
        var createdBomb = Instantiate(_bombPrefab, finalPosition, Quaternion.identity);
        createdBomb.transform.parent = _bombPlacement;
    }

    IEnumerator BombCooldownCo()
    {
        yield return new WaitForSeconds(_bombDataService.GetBombUseCooldown());
        _characterDataUpdate.AddBombAmount(1);
        _hudLogic.UpdateBomb();
    }
}
