using UnityEngine;

namespace SotongStudio.VContainer.Test
{
    public class MainComponent
    {
        private readonly ViewComponent _view;
        private readonly AdditionalComponent _additionalComponent;
        private readonly SubComponent _subComponent;

        public MainComponent(ViewComponent view, AdditionalComponent additionalCompoent, SubComponent subComponent)
        {
            Debug.Log("View :" + _view);
            _view = view;
            _additionalComponent = additionalCompoent;
            _subComponent = subComponent;
            Initial();
        }

        private void Initial()
        {
            _view.OnTestAction = TestAction;
        }

        public void TestAction()
        {
            _additionalComponent.CallFunction();
        }
    }
}
