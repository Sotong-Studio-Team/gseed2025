using SotongStudio.Bomber.Gameplay.Bomb;
using SotongStudio.Bomber.Gameplay.Character.DataService;
using SotongStudio.Bomber.Gameplay.Inventory;
using VContainer;
using UnityEngine;
using SotongStudio.Bomber.Gameplay.Character;

namespace SotongStudio.Bomber
{
    public class DataServiceInstaller : ScopeInstallHelper
    {
        [SerializeField] private CharacterStarterConfigSO _characterStarterConfigSO;
        [SerializeField] private BombStarterConfigSO _bombStarterConfigSO;
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<CharacterGameplayDataService>(Lifetime.Singleton)
                   .As<ICharacterGameplayDataService>()
                   .As<ICharacterGameplayUpdateService>()
                   .WithParameter(_characterStarterConfigSO);

            builder.Register<BombGameplayDataService>(Lifetime.Singleton)
                   .As<IBombGameplayDataService>()
                   .As<IBombGameplayUpdateService>()
                   .WithParameter(_bombStarterConfigSO);


            builder.Register<InventoryGameplayDataService>(Lifetime.Singleton)
                   .As<IInventoryGameplayDataService>()
                   .As<IInventoryGameplayUpdateService>();
        }
    }
}
