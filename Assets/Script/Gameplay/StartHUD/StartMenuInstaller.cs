using UnityEngine;
using VContainer;

namespace SotongStudio.Bomber
{
    public class StartMenuInstaller : ScopeInstallHelper
    {
        [SerializeField] private StartMenuView _startMenuView;
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<StartMenuLogic>(Lifetime.Singleton)
                    .WithParameter<IStartMenuView>(_startMenuView).AsSelf();
        }
    }
}
