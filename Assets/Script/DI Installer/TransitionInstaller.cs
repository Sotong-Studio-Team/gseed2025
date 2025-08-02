using SotongStudio.Bomber.Gameplay.Transition;
using UnityEngine;
using VContainer;

namespace SotongStudio.Bomber
{
    public class TransitionInstaller : ScopeInstallHelper
    {
        [SerializeField]
        TransitionComponent _transitionComponent;
        [SerializeField]
        TransitionComponentMarket _marketTransitionComponent;
        [SerializeField]
        TransitionComponentAltar _altarTransitionComponent;

        public override void Install(IContainerBuilder builder)
        {
            builder.Register<TransitionController>(Lifetime.Singleton).As<ITransitionController>()
                    .WithParameter(_transitionComponent)
                    .WithParameter(_marketTransitionComponent)
                    .WithParameter(_altarTransitionComponent);

        }
    }
}
