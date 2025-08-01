using UnityEngine;
using VContainer;
using VContainer.Unity;

public class TestLifetimeScope : LifetimeScope
{

    [SerializeField] private PlayerMovementView _playerMovementView;
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterEntryPoint<PlayerMovementLogic>();
        builder.RegisterComponent(_playerMovementView);
        builder.Register<PlayerMovementModel>(Lifetime.Singleton);
    }
}
