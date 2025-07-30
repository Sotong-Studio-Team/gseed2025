using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SotongStudio.VContainer
{
    public class VContainerInstallerObject : MonoBehaviour, IInstaller, ISerializationCallbackReceiver
    {
        public virtual void Install(IContainerBuilder builder)
        {
            throw new System.NotImplementedException();
        }

        public virtual void OnAfterDeserialize()
        {
            throw new System.NotImplementedException();
        }

        public virtual void OnBeforeSerialize()
        {
            throw new System.NotImplementedException();
        }
    }
}
