using UnityEngine;
using VContainer;

namespace SotongStudio.Bomber.Gameplay.HUD
{
    public class GameplayHUDInstaller : ScopeInstallHelper
    {
        [SerializeField] private GameplayHUDView _gameplayHUDView;
        [SerializeField] private HealthHUDView _healthHUDView;

        public override void Install(IContainerBuilder builder)
        {
            builder.Register<GameplayHudLogic>(Lifetime.Singleton).As<IGameplayHudLogic>()
                    .WithParameter<IGameplayHUDView>(_gameplayHUDView)
                    .WithParameter<IHealthHUDView>(_healthHUDView);
        }
    }
}
