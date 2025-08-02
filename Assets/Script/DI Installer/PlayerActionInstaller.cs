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
        [SerializeField]
        private PlayerBombView _playerBombView;
        [SerializeField]
        private PlayerHitView _playerHitView;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<PlayerMovementLogic>().AsSelf();
            builder.RegisterComponent(_playerMovementView);
            builder.RegisterComponent(_playerInputView);
            builder.RegisterComponent(_playerBombView);
            builder.RegisterComponent(_playerHitView);
        }
    }
}
