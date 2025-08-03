using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SotongStudio.Bomber
{
    public interface IGameOverHUDView
    {
        UnityEvent OnPlayAgain { get; }
        void SetCrystalCount(int count);
        void Show();
    }
    public class GameOverHUDView : MonoBehaviour, IGameOverHUDView
    {
        [SerializeField]
        private TMP_Text _crystalText;
        [SerializeField]
        private TMP_Text _clearAmount;

        [SerializeField]
        private Button _playAgainButton;

        [SerializeField]
        private readonly CanvasGroup _canvasGroup;
        public UnityEvent OnPlayAgain => _playAgainButton.onClick;
        public void SetCrystalCount(int count)
        {
            _crystalText.text = $"x{count}";
        }
        public void SetClearAmount(int clearAmount)
        {
            _clearAmount.text = $"Cleared: {clearAmount} Time(s)";
        }

        public void Show()
        {
            _canvasGroup.Show();
        }

        

    }
}

