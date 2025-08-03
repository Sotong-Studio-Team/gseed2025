using UnityEngine;
using SotongStudio.Utilities.AudioSystem;

public class PlayerPickItemView : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IPickable pickable = collision.gameObject.GetComponent<IPickable>();
        if(pickable != null)
        {
            pickable.PickUp();
            BasicAudioSystem.Instance.PlaySFX("pick");
        }
    }
}
