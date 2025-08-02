using UnityEngine;

namespace SotongStudio.Bomber
{
    public class AltarInteractionComponent : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private AltarController _altarController;
        public void Interact()
        {
            _altarController.ShowAltar();
        }

    }
}
