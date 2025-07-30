using NaughtyAttributes;
using UnityEngine;

namespace SotongStudio.VContainer.Test
{
    public class ViewComponent : MonoBehaviour
    {
        public System.Action OnTestAction;

        [Button]
        private void CallTest()
        {
            OnTestAction.Invoke();
        }
    }
}
