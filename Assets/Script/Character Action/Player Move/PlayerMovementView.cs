using SotongStudio.Bomber;
using UnityEngine;
using SotongStudio.Utilities.AudioSystem;

public class PlayerMovementView : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private SpriteRenderer _sprite;
    [SerializeField]
    private GameObject _visualObject;

    private void Start()
    {
        //_rb = GetComponent<Rigidbody2D>();
        //_animator = GetComponent<Animator>();
        //_sprite = GetComponent<SpriteRenderer>();

        AnimatePlayer(Vector2.down, Vector2.zero);
    }

    public void MovePlayer(float moveSpeed, Vector2 movement)
    {
        _rb.MovePosition(_rb.position + moveSpeed * Time.fixedDeltaTime * movement.normalized);
    }

    public void AnimatePlayer(Vector2 lastDirection, Vector2 movement)
    {
        bool isWalking;

        //set parameter idle animation player
        //_animator.SetFloat("dirX", lastDirection.x);
        //_animator.SetFloat("dirY", lastDirection.y);

        ////set parameter walk animation player
        //_animator.SetFloat("moveX", movement.x);
        //_animator.SetFloat("moveY", movement.y);

        if (movement != Vector2.zero)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

        _animator.SetBool("isWalking", isWalking);
    }

    public void FlipSprite(bool isFlipped)
    {
        var newScale = new Vector3(!isFlipped ? -1 : 1, 1, 0);
        _visualObject.transform.localScale = newScale;
    }
}
