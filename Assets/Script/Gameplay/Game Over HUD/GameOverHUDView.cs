using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SotongStudio.Bomber
{
    public interface IGameOverHUDView
    {
        UnityEvent OnPlayAgain { get; }

        void SetClearAmount(int currentLevel);
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
        private CanvasGroup _canvasGroup;
        public UnityEvent OnPlayAgain => _playAgainButton.onClick;
        public void SetCrystalCount(int count)
        {
            _crystalText.text = $"and collected x{count}";
        }
        public void SetClearAmount(int clearAmount)
        {
            _clearAmount.text = $"You have accompanied ALICE for around {clearAmount} Levels,";
        }

        public void Show()
        {
            _canvasGroup.Show();
        }

        

    }
}

