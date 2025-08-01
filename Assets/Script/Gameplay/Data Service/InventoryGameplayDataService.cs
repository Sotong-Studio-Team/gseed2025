namespace SotongStudio.Bomber.Gameplay.Inventory
{
    public interface IInventoryGameplayDataService
    {
        int GetOwnedCrystal();
    }
    public interface IInventoryGameplayUpdateService
    {
        void ReduceOwnedCrystal(int value);
        void AddOwnedCrystal(int value);
    }
    public class InventoryGameplayDataService : IInventoryGameplayDataService, IInventoryGameplayUpdateService
    {
        private int _ownedCrystal = 0;

        public void AddOwnedCrystal(int value)
        {
            _ownedCrystal += value;
        }

        public int GetOwnedCrystal()
        {
            return _ownedCrystal;
        }

        public void ReduceOwnedCrystal(int value)
        {
            _ownedCrystal -= value;
        }
    }
}
