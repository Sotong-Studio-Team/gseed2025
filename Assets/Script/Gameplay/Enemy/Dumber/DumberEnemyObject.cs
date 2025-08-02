using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.DungeonObject.Enemy
{
    public interface IDumberEnemy
    {
        IDumberEnemyVisual Visual { get; }
        IDumberEnemyBehaviour Behaviour { get; }
    }
    public class DumberEnemyObject : EnemyObject, IDumberEnemy
    {
        [SerializeField] 
        DumberEnemyVisual _hunterVisual;
        
        [SerializeField]
        DumberEnemyBehaviours _hunterBehaviours;
        
        public IDumberEnemyVisual Visual => _hunterVisual;
        public IDumberEnemyBehaviour Behaviour => _hunterBehaviours;

        public override void InitializeProcess()
        {
            base.InitializeProcess();
            InternalSetup();
        }
        public override void ShowUpProcess()
        {
            Debug.Log("Show Up Proses Enemy Dumber");
            base.ShowUpProcess();

            //Play Wake Up Animation
            _hunterBehaviours.StartBehaviour();
        }

        public override void TakeExplosionDamageProcess(int damage)
        {
            Debug.Log("Dumber Take Explosion damage");
            Object.Destroy(gameObject);
        }
        private void InternalSetup()
        {
            //Setup Visual
            _hunterBehaviours.InternalSetup();
        }
    }
}
