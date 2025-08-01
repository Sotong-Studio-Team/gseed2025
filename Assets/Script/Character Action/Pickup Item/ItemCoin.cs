using UnityEngine;

public class ItemCoin : MonoBehaviour, IPickable
{
    public void PickUp()
    {
        DestroyObject();
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
