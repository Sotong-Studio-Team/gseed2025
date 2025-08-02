using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SotongStudio.Bomber
{
    public class StartMenuInstaller : ScopeInstallHelper
    {
        [SerializeField] private StartMenuView _startMenuView;
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<StartMenuLogic>(Lifetime.Singleton)
                    .As<IInitializable>()
                    .WithParameter<IStartMenuView>(_startMenuView).AsSelf();
        }
    }
}
