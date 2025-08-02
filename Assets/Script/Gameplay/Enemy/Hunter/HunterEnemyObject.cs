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
            Debug.Log("Hunter Take Explosion damage");
            Destroy(gameObject);
        }
        private void InternalSetup()
        {
            //Setup Visual
            _hunterBehaviours.InternalSetup();
        }
    }
}
