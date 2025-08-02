using NaughtyAttributes;
using SotongStudio.Bomber.Gameplay.Bomb.Data;
using SotongStudio.Bomber.Gameplay.Bomb;
using SotongStudio.Bomber.Gameplay.Character.DataService;
using SotongStudio.Bomber.Gameplay.Character;
using SotongStudio.Bomber.Gameplay.Inventory;
using UnityEngine;
using VContainer;

namespace SotongStudio.Bomber
{
    public class MarketDataTest : MonoBehaviour
    {
        [SerializeField]
        private BombStarterConfigSO _bombStat;
        [SerializeField]
        private CharacterStarterConfigSO _characterStat;


        private ICharacterGameplayDataService _characterDataService;
        private ICharacterGameplayUpdateService _characterDataUpdate;

        private IBombGameplayDataService _bombDataService;
        private IBombGameplayUpdateService _bombDataUpdate;

        private IInventoryGameplayDataService _inventoryDataService;
        private IInventoryGameplayUpdateService _inventoryDataUpdate;

        private int _bombAmount;

        [Inject]
        public void Inject(ICharacterGameplayDataService characterDataService, ICharacterGameplayUpdateService characterDataUpdate,
                           IBombGameplayDataService bombDataService, IBombGameplayUpdateService bombDataUpdate,
                           IInventoryGameplayDataService inventoryDataService, IInventoryGameplayUpdateService inventoryDataUpdate)
        {
            _characterDataService = characterDataService;
            _characterDataUpdate = characterDataUpdate;

            _bombDataService = bombDataService;
            _bombDataUpdate = bombDataUpdate;

            _inventoryDataService = inventoryDataService;
            _inventoryDataUpdate = inventoryDataUpdate;

        }
        
        public void Setup()
        {
            _characterDataUpdate.SetupCharacterStat(new CharacterStatGameplay(_characterStat));
            _bombDataUpdate.SetupBombStat(new BombStat(_bombStat));

            _inventoryDataUpdate.AddOwnedCrystal(30);
        }

        public void Heal()
        {
            _characterDataUpdate.AddPlayerHealth(_characterDataService.GetCharacterMaxHealth());
        }
        public void AddMaxHP()
        {
            _characterDataUpdate.AddPlayerMaxHealth(1);
        }
        public void AddSpeed()
        {
            _characterDataUpdate.AddPlayerSpeed(1);
        }

        public void AddBomb()
        {
            _bombAmount++;
        }
        public void AddExplosion()
        {
            _bombDataUpdate.AddBombRange(1);
        }

        public int GetCurrency()
        {
            return _inventoryDataService.GetOwnedCrystal();
        }

        public void BuyingSucceed(int reduction)
        {
            _inventoryDataUpdate.ReduceOwnedCrystal(reduction);
        }

        public void PrintStat()
        {
            Debug.Log($"Health : {_characterDataService.GetCharacterCurrentHealth()}" +
                $"| Speed : {_characterDataService.GetCharacterSpeed()}" +
                $"| Max Health : {_characterDataService.GetCharacterMaxHealth()}" +
                $"| Amount : {_bombAmount}" +
                $"| Range : {_bombDataService.GetBombRange()}" +
                $"| Crystal : {_inventoryDataService.GetOwnedCrystal()}");
        }
    }
}

