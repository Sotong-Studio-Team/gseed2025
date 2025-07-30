using UnityEngine;
using UnityEngine.Events;

namespace SotongStudio.Bomber.Gameplay.DungeonObject
{
    public interface IDungeonObject
    {
        UnityEvent OnDestroyedObject { get; }

        void InitializeProcess();

        void ShowAsCovered();
        void ShowUpProcess();
        void TakeExplosionDamageProcess(int damage);

        void RemoveFromFieldProcess();

    }
    public abstract class DungeonObject : MonoBehaviour, IDungeonObject
    {
        public UnityEvent OnDestroyedObject { get; private set; } = new();

        public virtual void ShowUpProcess()
        {
            gameObject.SetActive(true);
        }

        public void ShowAsCovered()
        {
            gameObject.SetActive(false);
        }
        public abstract void TakeExplosionDamageProcess(int damage);
        public virtual void InitializeProcess()
        {

        }


        public virtual void RemoveFromFieldProcess()
        {

        }
    }
}
