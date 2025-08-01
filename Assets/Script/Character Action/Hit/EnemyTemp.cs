using UnityEngine;

public class EnemyTemp : MonoBehaviour
{
    [SerializeField] private int _damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out PlayerHitView player))
        {
            player.Hit(_damage);
        }
    }
}
