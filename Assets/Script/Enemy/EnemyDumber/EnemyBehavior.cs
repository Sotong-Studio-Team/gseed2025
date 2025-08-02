using SotongStudio.Bomber.Gameplay.DungeonObject.Enemy;
using UnityEngine;
using UnityEngine.AI;

namespace SotongStudio.Bomber
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyBehavior : EnemyObject
    {
        [Header("Enemy Data")]
        public Enemy enemyData = new Enemy();

        [Header("Roaming Settings")]
        public LayerMask obstacleLayers;         // layer untuk obstacle atau tembok
        public float safeDistance = 0.2f;        // jarak aman biar ga dempet
        public float checkDistance = 0.5f;       // jarak cek raycast
        public float navmeshCheckDistance = 1f;  // jarak cek ujung NavMesh

        private EnemyRoaming roaming;     // modul roaming
        private Rigidbody2D rb;           // komponen rigidbody
        private Collider2D col;           // komponen collider

        public override void InitializeProcess()
        {
            rb = GetComponent<Rigidbody2D>();
            col = GetComponent<Collider2D>();

            // inisialisasi class roaming logic
            roaming = new EnemyRoaming(
                transform,
                GetComponent<NavMeshAgent>(),
                rb,
                obstacleLayers,
                enemyData.moveSpeed,
                safeDistance,
                checkDistance,
                navmeshCheckDistance
            );

            // setup physics
            rb.gravityScale = 0;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        public override void ShowUpProcess()
        {
            roaming.Start();
        }
        private void FixedUpdate()
        {
            // jalankan logic roaming tiap physics frame
            roaming.Checking();
        }

        public override void TakeExplosionDamageProcess(int damage)
        {
            Die();
            base.TakeExplosionDamageProcess(damage);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // Makduear
            if (collision.collider.CompareTag("Player"))
            {
                Die();
            }
        }

        // fungsi mati / destroy enemy
        private void Die()
        {
            Destroy(gameObject);
        }

        // tampilkan gizmo debug arah & navmesh
        private void OnDrawGizmosSelected()
        {
            if (roaming != null)
                roaming.DrawGizmos();
        }
    }
}
