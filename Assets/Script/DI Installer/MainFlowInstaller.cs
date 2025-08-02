using SotongStudio.Bomber.Gameplay;
using SotongStudio.Bomber.Gameplay.LevelManager;
using VContainer;
using VContainer.Unity;
using UnityEngine; 

namespace SotongStudio.Bomber
{
    public class MainFlowInstaller : ScopeInstallHelper
    {
        [SerializeField]
        private LevelManagerData _levelManagerData;
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<LevelManager>(Lifetime.Singleton).As<ILevelManager>()
                   .WithParameter(_levelManagerData);
            builder.RegisterEntryPoint<MainGameFlowControl>(Lifetime.Singleton).As<IPostStartable>();
        }
    }
}
