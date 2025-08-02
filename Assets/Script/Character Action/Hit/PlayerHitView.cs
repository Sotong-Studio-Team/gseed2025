using SotongStudio.Bomber;
using SotongStudio.Bomber.Gameplay.Bomb;
using SotongStudio.Bomber.Gameplay.Character.DataService;
using System.Collections;
using UnityEngine;
using UnityEngine.Android;
using VContainer;

public class PlayerHitView : MonoBehaviour, IDamageable
{
    private ICharacterGameplayDataService _characterDataService;
    private ICharacterGameplayUpdateService _characterDataUpdate;

    [Inject]
    public void Inject(ICharacterGameplayDataService characterDataService, ICharacterGameplayUpdateService characterDataUpdate)
    {
        _characterDataService = characterDataService;
        _characterDataUpdate = characterDataUpdate;
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

        if (_characterDataService.GetCharacterCurrentHealth() <= 0)
        {
            Die();
        }
        else
        {
            _characterDataUpdate.ReducePlayerHealth(amount);
            Debug.Log($"Player health = {_characterDataService.GetCharacterCurrentHealth()}/{_characterDataService.GetCharacterMaxHealth()}");
            StartCoroutine(InvincibleCo());
        }
    }

    private void Die()
    {
        Debug.Log("Player died");
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
