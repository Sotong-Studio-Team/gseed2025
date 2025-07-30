using NaughtyAttributes;
using SotongStudio.Bomber.Gameplay.Bomb;
using SotongStudio.Bomber.Gameplay.Bomb.Data;
using SotongStudio.Bomber.Gameplay.Character;
using SotongStudio.Bomber.Gameplay.Character.DataService;
using SotongStudio.Bomber.Gameplay.Inventory;
using UnityEngine;
using VContainer;

namespace SotongStudio.Bomber.Gameplay.Test
{
    public class GameplayDataServiceTest : MonoBehaviour
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
        [Button]
        private void Setup()
        {
            _characterDataUpdate.SetupCharacterStat(new CharacterStatGameplay(_characterStat));
            _bombDataUpdate.SetupBombStat(new BombStat(_bombStat));
        }

        [Button]
        private void AddCharacterStat()
        {
            _characterDataUpdate.AddPlayerMaxHealth(10);
            _characterDataUpdate.AddPlayerHealth(5);
            _characterDataUpdate.AddPlayerSpeed(1);
        }
        [Button]
        private void AddBombStat()
        {
            _bombDataUpdate.AddBombDamage(10);
            _bombDataUpdate.AddBombRange(1);

            PrintStat();
        }
        [Button]
        private void ReduceCharacterStat()
        {
            _characterDataUpdate.ReducePlayerMaxHealth(5);
            _characterDataUpdate.ReducePlayerHealth(2);
            _characterDataUpdate.ReducePlayerSpeed(1);

            PrintStat();
        }
        [Button]
        private void ReduceBombStat()
        {
            _bombDataUpdate.ReduceBombDamage(10);
            _bombDataUpdate.ReduceBombRange(1);

            PrintStat();
        }


        [Button]
        private void PrintStat()
        {
            Debug.Log($"Character Stat - " +
                $"Health : {_characterDataService.GetCharacterCurrentHealth()}" +
                $"| Speed : {_characterDataService.GetCharacterSpeed()}" +
                $"| Max Health : {_characterDataService.GetCharacterMaxHealth()}");

            Debug.Log($"Bomb Stat - " +
                $"Damage : {_bombDataService.GetBombDamage()}" +
                $"| Range : {_bombDataService.GetBombRange()}" +
                $"| Explode Duration : {_bombDataService.GetBombExplosionDuration()}" +
                $"| Delay : {_bombDataService.GetBombExplosionDelay()}" +
                $"| Cooldown : {_bombDataService.GetBombUseCooldown()}");
        }
    }
}

