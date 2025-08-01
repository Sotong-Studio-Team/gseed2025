using SotongStudio.Bomber.Gameplay.Bomb;
using SotongStudio.Bomber.Gameplay.Character.DataService;
using SotongStudio.Bomber.Gameplay.Inventory;
using VContainer;

namespace SotongStudio.Bomber
{
    public class DataServiceInstaller : ScopeInstallHelper
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<CharacterGameplayDataService>(Lifetime.Singleton)
                   .As<ICharacterGameplayDataService>()
                   .As<ICharacterGameplayUpdateService>();

            builder.Register<BombGameplayDataService>(Lifetime.Singleton)
                   .As<IBombGameplayDataService>()
                   .As<IBombGameplayUpdateService>();

            builder.Register<InventoryGameplayDataService>(Lifetime.Singleton)
                   .As<IInventoryGameplayDataService>()
                   .As<IInventoryGameplayUpdateService>();
        }
    }
}
