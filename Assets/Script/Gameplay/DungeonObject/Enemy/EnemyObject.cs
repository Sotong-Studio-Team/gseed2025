namespace SotongStudio.Bomber.Gameplay.DungeonObject.Enemy
{
    public interface IEnemyObject : IDungeonObject
    {

    }
    public class EnemyObject : DungeonObject, IEnemyObject
    {
        public override void TakeExplosionDamageProcess(int damage)
        {
            // Calculate Damage
        }
    }
}
