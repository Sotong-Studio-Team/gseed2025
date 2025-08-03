#nullable enable

using System.Collections;
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
            var spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
            var materials = new Material[spriteRenderers.Length];

            for (int i = 0; i < spriteRenderers.Length; i++)
            {
                materials[i] = spriteRenderers[i].material;
            }

            StartCoroutine(PlayVanishThenDestroy(materials));
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
        
        private IEnumerator PlayVanishThenDestroy(Material[] materials)
        {
            yield return ShaderController.Vanish(materials);

            gameObject.SetActive(false);
            OnDestroyedObject.Invoke();
        }


    }
}
