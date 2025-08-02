using SotongStudio.Bomber.Gameplay.HUD;
using SotongStudio.Bomber.Gameplay.Inventory;
using VContainer;

namespace SotongStudio.Bomber.Gameplay.DungeonObject.DropItem
{
    public interface ICrystalDropItem : IDropItem
    {
        // Additional methods or properties specific to crystal drop items can be defined here.
    }   
    public class CrystalDropItem : DropItem, ICrystalDropItem
    {
        private IGameplayHudLogic _gameplayHUD;
        private IInventoryGameplayUpdateService _inventoryUpdate;

        [Inject]
        private void Inject(IGameplayHudLogic gameplayHUD,
                            IInventoryGameplayUpdateService inventoryUpdate)
        {
            _gameplayHUD = gameplayHUD;
            _inventoryUpdate = inventoryUpdate;
        }
        public override void OnPickUpProcess()
        {
            base.OnPickUpProcess();

            _inventoryUpdate.AddOwnedCrystal(1);
            _gameplayHUD.UpdateCrystal();
        }
    }
}
