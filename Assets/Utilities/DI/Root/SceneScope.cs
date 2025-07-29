using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SotongStudio
{
    public abstract class SceneScope : LifetimeScope
    {
        [Header("Registered Installer")]
        [ReadOnly]
        [SerializeField]
        private List<ScopeInstallHelper> _installers;

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            AddRegistration(builder);
            InternalConfigure(builder);
        }

        protected abstract void AddRegistration(IContainerBuilder builder);
        private void InternalConfigure(IContainerBuilder builder)
        {
            foreach (var installer in _installers)
            {
                installer.Install(builder);
            }
        }

#if UNITY_EDITOR
        [Button]
        private void FindInstaller()
        {
            Debug.Log("Find Installer");
            gameObject.GetComponentsInChildren<ScopeInstallHelper>(_installers);
        }
#endif
    }
}
