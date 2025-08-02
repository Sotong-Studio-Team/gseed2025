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
        public UnityEvent OnStartMenu => _startButton.onClick;
    }
}
