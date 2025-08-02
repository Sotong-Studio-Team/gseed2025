using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SotongStudio.Bomber.Gameplay.HUD
{
    public interface IHealthHUDView
    {
        //void UpdateMaxHealth(int currentMaxHealth);
        void UpdateCurrentHealth(int currentHealth);
    }
    public class HealthHUDView : MonoBehaviour, IHealthHUDView
    {
        //[SerializeField]
        //private Image[] _maxHealthImages;
        [SerializeField]
        private Image[] _currentHealthImages;
        public void UpdateCurrentHealth(int currentHealth)
        {
            int i = 0;
            for (; i < currentHealth; i++)
            {
                _currentHealthImages[i].enabled = true;
            }
            for (; i < _currentHealthImages.Length; i++)
            {
                _currentHealthImages[i].enabled = false;
            }
        }

        //public void UpdateMaxHealth(int currentMaxHealth)
        //{
        //    int i = 0;
        //    for (; i < currentMaxHealth; i++)
        //    {
        //        _maxHealthImages[i].enabled = true;
        //    }
        //    for (; i < _maxHealthImages.Length; i++)
        //    {
        //        _maxHealthImages[i].enabled = false;
        //    }
        //}
    }
}
