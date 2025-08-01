using UnityEngine;

public class PlayerPickItemView : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IPickable pickable = collision.gameObject.GetComponent<IPickable>();
        if(pickable != null)
        {
            pickable.PickUp();
        }
    }
}
