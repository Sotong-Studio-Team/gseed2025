using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SotongStudio
{
    public abstract class ScopeInstallHelper : MonoBehaviour, IInstaller
    {
        public abstract void Install(IContainerBuilder builder);
    }
}
