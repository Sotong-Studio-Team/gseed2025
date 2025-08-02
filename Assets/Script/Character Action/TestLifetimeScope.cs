using SotongStudio.Bomber;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class TestLifetimeScope : LifetimeScope
{

    [SerializeField] private PlayerMovementView _playerMovementView;
    [SerializeField] private PlayerInputView _playerInputView;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterEntryPoint<PlayerMovementLogic>();

        builder.RegisterComponent(_playerMovementView);
        builder.RegisterComponent(_playerInputView);

    }
}
