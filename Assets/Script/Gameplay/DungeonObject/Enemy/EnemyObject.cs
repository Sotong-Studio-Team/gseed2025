namespace SotongStudio.Bomber.Gameplay.DungeonObject.Enemy
{
    public interface IEnemyObject : IDungeonObject, IDamageable
    {

    }
    public class EnemyObject : DungeonObject, IEnemyObject
    {
        public void Damage(int amount)
        {
            TakeExplosionDamageProcess(amount);
        }

        public override void TakeExplosionDamageProcess(int damage)
        {
            // Calculate Damage
        }
    }
}
