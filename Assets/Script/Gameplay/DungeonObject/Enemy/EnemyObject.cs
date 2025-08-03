using UnityEngine;

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

        private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
        {
            if (collision.TryGetComponent<IDamageablePlayer>(out var component)
                && Vector2.Distance(transform.position, collision.transform.position) < 1)
            {

                component.TakeDamage(1);
                TakeExplosionDamageProcess(999); // Make Sure Enemy die  after hit PLayer
            }
        }
    }
}
