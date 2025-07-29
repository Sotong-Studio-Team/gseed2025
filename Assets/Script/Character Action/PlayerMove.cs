using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator;
    private Vector2 _movement;
    private Vector2 _lastDirection = Vector2.down;
    [SerializeField] private float _moveSpeed = 10f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        AnimatePlayer();

        CheckInput();

        if (_movement != Vector2.zero)
        {
            MovePlayer();
        }
    }

    private void CheckInput()
    {
        _movement.x = Input.GetAxis("Horizontal");
        _movement.y = Input.GetAxis("Vertical");
    }

    public void MovePlayer()
    {
        _rb.MovePosition(_rb.position + _moveSpeed * Time.fixedDeltaTime * _movement.normalized);
    }

    private void AnimatePlayer()
    {
        bool isWalking;

        //set parameter idle animation player
        _animator.SetFloat("dirX", _lastDirection.x);
        _animator.SetFloat("dirY", _lastDirection.y);

        //set parameter walk animation player
        _animator.SetFloat("moveX", _movement.x);
        _animator.SetFloat("moveY", _movement.y);

        if (_movement != Vector2.zero)
        {
            isWalking = true;

            _lastDirection = _movement;
        }
        else
        {
            isWalking = false;
        }

        _animator.SetBool("isWalking", isWalking);
    }
}
