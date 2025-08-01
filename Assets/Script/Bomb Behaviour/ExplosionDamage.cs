using UnityEngine;

namespace SotongStudio.Bomber
{
    public class ExplosionDamage : MonoBehaviour
    {
        [SerializeField] private int _explosionDamage= 1;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IDamageable damageable))
            {
                //Cuman works buat Player
                damageable?.Damage(_explosionDamage);
            }

        }
    }
}
