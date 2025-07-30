using UnityEngine;

public class PlayerPickItemView : MonoBehaviour
{
    private Collider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IPickable pickable = collision.gameObject.GetComponent<IPickable>();
        if(pickable != null)
        {
            pickable.PickUp();
        }

    }
}
