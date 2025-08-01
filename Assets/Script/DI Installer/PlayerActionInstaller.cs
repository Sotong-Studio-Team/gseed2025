using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SotongStudio.Bomber
{
    public class PlayerActionInstaller : ScopeInstallHelper
    {
        [SerializeField] 
        private PlayerMovementView _playerMovementView;
        [SerializeField] 
        private PlayerInputView _playerInputView;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<PlayerMovementLogic>().AsSelf();
            builder.RegisterComponent(_playerMovementView);
            builder.RegisterComponent(_playerInputView);
            builder.Register<PlayerMovementModel>(Lifetime.Singleton);
        }
    }
}
