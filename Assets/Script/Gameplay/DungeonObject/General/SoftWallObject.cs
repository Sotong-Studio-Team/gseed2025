#nullable enable

using UnityEngine;
using SotongStudio.Utilities.AudioSystem;

namespace SotongStudio.Bomber.Gameplay.DungeonObject
{
    public interface ISoftWallObject : IDungeonObject, IDamageable
    {
        void SetLinkedObject(IDungeonObject linkedObject);
    }
    public class SoftWallObject : DungeonObject, ISoftWallObject
    {
        private IDungeonObject? _linkedObject = null;

        public override void InitializeProcess()
        {
            OnDestroyedObject.AddListener(RevealLinkedTarget);
        }

        public void Damage(int amount)
        {
            TakeExplosionDamageProcess(amount);
            Debug.Log("Take damage");
            BasicAudioSystem.Instance.PlaySFX("tanahnya jatuh setelah meledak v2");
        }
        public override void TakeExplosionDamageProcess(int damage)
        {
            gameObject.SetActive(false);
            OnDestroyedObject.Invoke();
        }


        private void RevealLinkedTarget()
        {
            _linkedObject?.ShowUpProcess();
        }

        public void SetLinkedObject(IDungeonObject linkedObject)
        {
            _linkedObject = linkedObject;
        }

        public override void RemoveFromFieldProcess()
        {
            _linkedObject = null;
            OnDestroyedObject.RemoveListener(RevealLinkedTarget);

            base.RemoveFromFieldProcess();
        }

    }
}
