using System.Collections;
using SotongStudio.Bomber;
using SotongStudio.Bomber.Gameplay.Bomb;
using SotongStudio.Bomber.Gameplay.Character.DataService;
using SotongStudio.Bomber.Gameplay.HUD;
using SotongStudio.Utilities.Vector2Helper;
using UnityEngine;
using UnityEngine.Events;
using VContainer;

public class PlayerBombView : MonoBehaviour
{
    //[SerializeField] private GridForBomb _grid;

    private ICharacterGameplayDataService _characterDataService;
    private ICharacterGameplayUpdateService _characterDataUpdate;
    private IGameplayHudLogic _hudLogic;
    private IBombGameplayDataService _bombDataService;
    private IObjectResolver _objectResolver;

    [Inject]
    public void Inject(ICharacterGameplayDataService characterDataService,
                       ICharacterGameplayUpdateService characterDataUpdate,
                       IBombGameplayDataService bombDataService,
                       IGameplayHudLogic hudLogic,
                       IObjectResolver objectResolver)
    {
        _characterDataService = characterDataService;
        _bombDataService = bombDataService;
        _characterDataUpdate = characterDataUpdate;

        _hudLogic = hudLogic;

        _objectResolver = objectResolver;

    }

    [SerializeField] private ExplosionLineControl _bombPrefab;
    [SerializeField] private Transform _bombPlacement;

    [SerializeField] private Vector3 _bombOffset = new (0,0.5f,0);
    private Vector3 _finalPosition;
    [SerializeField] private float _distance = 0.5f;
    [SerializeField] private Animator _animator;

    public UnityEvent OnBombDeployed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _characterDataService.GetBombAmount() > 0)
        {
            _characterDataUpdate.ReduceBombAmount(1);
            _hudLogic.UpdateBomb();
            PlaceBomb();
            StartCoroutine(BombCooldownCo());
        }
    }

    public bool IsWallDetected()
    {
        Vector2 origin = transform.position;
        LayerMask layerMask = LayerMask.GetMask("Wall");

        RaycastHit2D hit = Physics2D.Raycast(origin, _finalPosition, _distance, layerMask);

        if (hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void PlaceBomb()
    {
        _finalPosition = WorldSnappingPos.SnapWorldPosition(transform.position + _bombOffset);
        if (IsWallDetected() && transform.position.y > _finalPosition.y)
        {
            _finalPosition.y++;
        }
        //_grid.GetNearestPointOnGrid(point);
        var createdBomb = Instantiate(_bombPrefab, _finalPosition - _bombOffset, Quaternion.identity);
        createdBomb.transform.parent = _bombPlacement;

        _objectResolver.Inject(createdBomb);
    }

    IEnumerator BombCooldownCo()
    {
        yield return new WaitForSeconds(_bombDataService.GetBombUseCooldown());
        _characterDataUpdate.AddBombAmount(1);
        _hudLogic.UpdateBomb();
    }
}
