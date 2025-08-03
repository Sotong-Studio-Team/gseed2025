using System.Collections;
using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.DungeonObject.Enemy
{
    public interface IHunterEnemy
    {
        IHunterEnemyVisual Visual { get; }
        IHunterEnemyBehaviour Behaviour { get; }
    }
    public class HunterEnemyObject : EnemyObject, IHunterEnemy
    {
        [SerializeField]
        HunterEnemyVisual _hunterVisual;

        [SerializeField]
        HunterEnemyBehaviours _hunterBehaviours;

        public IHunterEnemyVisual Visual => _hunterVisual;
        public IHunterEnemyBehaviour Behaviour => _hunterBehaviours;

        public override void InitializeProcess()
        {
            base.InitializeProcess();
            InternalSetup();
        }
        public override void ShowUpProcess()
        {
            Debug.Log("Show Up Proses Enemy Hunter");
            base.ShowUpProcess();

            //Play Wake Up Animation
            _hunterBehaviours.StartBehaviour();
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
        private void InternalSetup()
        {
            //Setup Visual
            _hunterBehaviours.InternalSetup();
        }

        public void Update()
        {
            Visual.FlipVisualToRight(_hunterBehaviours._handledAgent.velocity.x > 0);
        }
        private IEnumerator PlayVanishThenDestroy(Material[] materials)
        {
            yield return ShaderController.Vanish(materials);

            gameObject.SetActive(false);
            OnDestroyedObject.Invoke();
        }
    }
}
