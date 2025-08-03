using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SotongStudio.Bomber
{
    public interface IStartMenuView
    {
        UnityEvent OnStartMenu { get; }
    }
         
    public class StartMenuView : MonoBehaviour, IStartMenuView
    {
        [SerializeField]
        private Button _startButton;

        [SerializeField]
        private CanvasGroup _canvasGroup;

        public UnityEvent OnStartMenu => _startButton.onClick;
        
        public void StartGame()
        {
            _canvasGroup.Hide();
        }
    }
}
