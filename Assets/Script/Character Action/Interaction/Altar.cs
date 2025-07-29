using UnityEngine;

public class Altar : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Altar accessed");
    }
}
