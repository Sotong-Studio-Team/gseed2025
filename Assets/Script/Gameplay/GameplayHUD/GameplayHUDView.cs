using TMPro;
using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.HUD
{
    public interface IGameplayHUDView
    {
        // Define methods and properties that the GameplayHUDView should implement
        void UpdateBombAmount(int bombAmount);
        void UpdateCrystalAmount(int crystalAmount);
    }
    public class GameplayHUDView : MonoBehaviour, IGameplayHUDView
    {
        [SerializeField]
        private TMP_Text _crystalAmountText;

        [SerializeField]
        private TMP_Text _bombAmountText;
        public void UpdateBombAmount(int bombAmount)
        {
            _bombAmountText.text = bombAmount.ToString();
        }

        public void UpdateCrystalAmount(int crystalAmount)
        {
            _crystalAmountText.text = $"X{crystalAmount}";
        }
    }
}
