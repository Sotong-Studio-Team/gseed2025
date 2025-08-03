using TMPro;
using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.HUD
{
    public interface IGameplayHUDView
    {
        // Define methods and properties that the GameplayHUDView should implement
        void UpdateBombAmount(int bombAmount);
        void UpdateCrystalAmount(int crystalAmount);
        void UpdateLevel(int level);
    }
    public class GameplayHUDView : MonoBehaviour, IGameplayHUDView
    {
        [SerializeField]
        private TMP_Text _crystalAmountText;

        [SerializeField]
        private TMP_Text _bombAmountText;

        [SerializeField]
        private TMP_Text _levelText;

        public void UpdateBombAmount(int bombAmount)
        {
            _bombAmountText.text = bombAmount.ToString();
        }

        public void UpdateCrystalAmount(int crystalAmount)
        {
            _crystalAmountText.text = crystalAmount.ToString();
        }

        public void UpdateLevel(int level)
        {
            _levelText.text = "Level " + level.ToString();
        }
    }
}
