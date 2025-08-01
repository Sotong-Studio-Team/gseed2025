using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SotongStudio.Bomber
{
    public class PlayerActionInstaller : ScopeInstallHelper
    {
        [SerializeField] 
        private PlayerMovementView _playerMovementView;
        
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<PlayerMovementLogic>().AsSelf();
            builder.RegisterComponent(_playerMovementView);
            builder.Register<PlayerMovementModel>(Lifetime.Singleton);
        }
    }
}
