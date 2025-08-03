namespace SotongStudio.Bomber.Gameplay.Inventory
{
    public interface IInventoryGameplayDataService
    {
        int GetOwnedCrystal();
        int GetRcordedCrystal();
    }
    public interface IInventoryGameplayUpdateService
    {
        void ReduceOwnedCrystal(int value);
        void AddOwnedCrystal(int value);
    }
    public class InventoryGameplayDataService : IInventoryGameplayDataService, IInventoryGameplayUpdateService
    {
        private int _ownedCrystal = 0;
        private int _recordedGetCrystal = 0;

        public void AddOwnedCrystal(int value)
        {
            _ownedCrystal += value;
            _recordedGetCrystal += value;
        }

        public int GetOwnedCrystal()
        {
            return _ownedCrystal;
        }

        public int GetRcordedCrystal()
        {
            return _recordedGetCrystal;
        }

        public void ReduceOwnedCrystal(int value)
        {
            _ownedCrystal -= value;
        }
    }
}
