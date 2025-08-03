using System.Collections;
using SotongStudio.Bomber;
using SotongStudio.Bomber.Gameplay.Character.DataService;
using SotongStudio.Bomber.Gameplay.HUD;
using UnityEngine;
using VContainer;

public class PlayerHitView : MonoBehaviour, IDamageable
{
    private ICharacterGameplayDataService _characterDataService;
    private ICharacterGameplayUpdateService _characterDataUpdate;
    private IGameplayHudLogic _gameplayHUD;
    private IGameOverHUDLogic _gameOverHUD;

    [Inject]
    public void Inject(ICharacterGameplayDataService characterDataService,
                       ICharacterGameplayUpdateService characterDataUpdate,
                       IGameplayHudLogic gameplayHUD,
                       IGameOverHUDLogic gameOverHUD)
    {
        _characterDataService = characterDataService;
        _characterDataUpdate = characterDataUpdate;
        _gameplayHUD = gameplayHUD;
        _gameOverHUD = gameOverHUD;
    }

    [SerializeField]
    private SpriteRenderer[] _sprites;
    private Collider2D _collider;
    private bool _isInvincible = false;
    [SerializeField] private float _invincibleDuration = 2f;
    [SerializeField] private float _flashInterval = 0.5f;

    private void Awake()
    {
        //_sprite = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
    }

    public void Damage(int amount)
    {
        if (_isInvincible)
        {
            return;
        }

        _characterDataUpdate.ReducePlayerHealth(amount);
        Debug.Log($"Player health = {_characterDataService.GetCharacterCurrentHealth()}/{_characterDataService.GetCharacterMaxHealth()}");
        _gameplayHUD.UpdateHealth();

        if (_characterDataService.GetCharacterCurrentHealth() <= 0)
        {
            Die();
        }

        StartCoroutine(InvincibleCo());

    }

    private void Die()
    {
        _gameOverHUD.Show();
        Time.timeScale = 0f; // Stop the game
    }

    private IEnumerator InvincibleCo()
    {
        _isInvincible = true;
        _collider.enabled = false;

        float timer = 0f;

        while (timer < _invincibleDuration)
        {
            foreach (var sprite in _sprites)
            {
                sprite.enabled = !sprite.enabled;
            }
            yield return new WaitForSeconds(_flashInterval);
            timer += _flashInterval;
        }

        foreach (var sprite in _sprites)
        {
            sprite.enabled = true;
        }
        _isInvincible = false;
        _collider.enabled = true;
    }
}
