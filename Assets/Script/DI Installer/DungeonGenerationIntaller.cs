using SotongStudio.Bomber.Gameplay.DungeonGeneration;
using SotongStudio.Bomber.Gameplay.DungeonGeneration.Service;
using VContainer;
using VContainer.Unity;
using UnityEngine;

namespace SotongStudio.Bomber
{
    public class DungeonGenerationIntaller : ScopeInstallHelper
    {
        [SerializeField]
        private DungeonGenerationView _generationView;
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<DungeonGenerationService>(Lifetime.Singleton)
                   .As<IDungeonGenerationService>();

            builder.Register<DungeonGenerationLogic>(Lifetime.Singleton)
                   .As<IDngeonGenerationLogic>()
                   .WithParameter<IDungeonGenerationView>(_generationView);
        }
    }
}
