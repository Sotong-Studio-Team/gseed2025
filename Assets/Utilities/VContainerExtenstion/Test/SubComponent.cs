using SotongStudio.VContainer.Test;
using VContainer.Unity;

namespace SotongStudio.VContainer
{
    public class SubComponent : IStartable
    {
        private readonly MainComponent _mainComponent;
        public SubComponent(MainComponent mainComponent)
        {
            _mainComponent = mainComponent;
        }

        public void Start()
        {
            _mainComponent.TestAction();
        }

        internal void TestCall()
        {
            UnityEngine.Debug.Log("Call Test in SUb");
        }
    }
}
