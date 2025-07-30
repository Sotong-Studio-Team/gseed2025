using System.Collections;
using UnityEngine;
using UnityEngine.Android;

public class PlayerHitView : MonoBehaviour
{
    private SpriteRenderer _sprite;
    private Collider2D _collider;
    private bool _isInvincible = false;
    [SerializeField] private float _invincibleDuration = 2f;
    [SerializeField] private float _flashInterval = 0.5f;

    private int _minHP = 1;
    private int _maxHP = 3;
    private int _currentHP;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();

        _currentHP = _maxHP;
    }

    public void Hit(int damage)
    {
        if (_isInvincible)
        {
            return;
        }

        _currentHP -= damage;
        Debug.Log($"Player health = {_currentHP}/{_maxHP}");

        if(_currentHP < 0)
        {
            Die();
        }
        else
        {
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
            _sprite.enabled = !_sprite.enabled;
            yield return new WaitForSeconds(_flashInterval);
            timer += _flashInterval;
        }

        _sprite.enabled = true;
        _isInvincible = false;
        _collider.enabled = true;
    }
}
