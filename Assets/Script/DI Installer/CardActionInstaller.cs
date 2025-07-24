using SotongStudio.ActLink.Gameplay;
using SotongStudio.ActLink.Gameplay.ActionProcessor;
using SotongStudio.ActLink.Gameplay.PlayerActionController;
using VContainer;

namespace SotongStudio.ActLink
{
    public class CardActionInstaller : ScopeInstallHelper
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<ActionProccessor>(Lifetime.Singleton).As<IActionProcessor>();
            builder.Register<BattleCardSelectionDataService>(Lifetime.Singleton).As<IBattleCardSelectionDataService>()
                                                                                .As<IBattleCardSelectionDataServiceUpdate>();

            // For Test
            builder.Register<PlayerCardSelectionController>(Lifetime.Singleton).As<IPlayerCardSelectionController>();
            builder.Register<EnemyCardSelectionController>(Lifetime.Singleton).As<IEnemyCardSelectionController>();
        }
    }
}
