using SotongStudio.Bomber.Gameplay.Character.DataService;
using SotongStudio.Bomber.Gameplay.Inventory;
using SotongStudio.Bomber.Gameplay.LevelManager;

namespace SotongStudio.Bomber.Gameplay.HUD
{
    public interface IGameplayHudLogic
    {
        void UpdateHealth();
        void UpdateBomb();
        void UpdateCrystal();
        void UpdateAllStat();
        void UpdateLevel(int level);
    }
    public class GameplayHudLogic : IGameplayHudLogic
    {
        private readonly ICharacterGameplayDataService _characterDataSerivce;
        private readonly IInventoryGameplayDataService _inventoryDataService;

        private readonly IGameplayHUDView _hudView;
        private readonly IHealthHUDView _healthHUDView;

        public GameplayHudLogic(IGameplayHUDView hudView,
                                IHealthHUDView healthHUD,

                                ICharacterGameplayDataService characterDataSerivce,
                                IInventoryGameplayDataService inventoryDataService)
        {
            _hudView = hudView;
            _healthHUDView = healthHUD;

            _characterDataSerivce = characterDataSerivce;
            _inventoryDataService = inventoryDataService;
        }
        public void UpdateHealth()  
        {
            _healthHUDView.UpdateMaxHealth(_characterDataSerivce.GetCharacterMaxHealth());
            _healthHUDView.UpdateCurrentHealth(_characterDataSerivce.GetCharacterCurrentHealth());
        }
        public void UpdateBomb()
        {
            _hudView.UpdateBombAmount(_characterDataSerivce.GetBombAmount());
        }
        public void UpdateCrystal()
        {
            _hudView.UpdateCrystalAmount(_inventoryDataService.GetOwnedCrystal());
        }
        public void UpdateLevel(int level)
        {
            _hudView.UpdateLevel(level);
        }

        public void UpdateAllStat()
        {
            UpdateHealth();
            UpdateBomb();
        }
    }
}
