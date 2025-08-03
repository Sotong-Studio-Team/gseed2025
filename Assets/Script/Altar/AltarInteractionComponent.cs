using UnityEngine;
using SotongStudio.Bomber.Gameplay.LevelManager;
using VContainer;

namespace SotongStudio.Bomber
{
    public class AltarInteractionComponent : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private AltarController _altarController;

        private ILevelManager _levelManager;
        private int _lastInteractedLevel = -1;

        [Inject]
        public void Construct(ILevelManager levelManager)
        {
            _levelManager = levelManager;
        }

        public void Interact()
        {
            if (_levelManager == null) return;

            int currentLevel = _levelManager.GetCurrentLevel();

            if (_lastInteractedLevel == currentLevel)
            {
                Debug.Log("kamu sudah pakai tadi");
                return;
            }
                

            _lastInteractedLevel = currentLevel;
            _altarController.ShowAltar();
        }
    }
}