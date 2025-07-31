using System;
using UnityEngine;
using UnityEngine.AI;

namespace SotongStudio.Bomber
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyBehavior : MonoBehaviour
    {
        [Header("Enemy Data")]
        public Enemy enemyData = new Enemy();

        [Header("Roaming Settings")]
        public float navmeshCheckDistance = 1f;  // jarak cek ujung NavMesh

        private EnemyRoaming roaming;     // modul roaming
        private Rigidbody2D rb;           // komponen rigidbody
        private Collider2D col;           // komponen collider

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            col = GetComponent<Collider2D>();

            // inisialisasi class roaming logic
            roaming = new EnemyRoaming(
                transform,
                GetComponent<NavMeshAgent>(),
                rb,
                enemyData.moveSpeed,
                navmeshCheckDistance
            );

            // setup physics
            rb.gravityScale = 0;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        private void Start()
        {
            // mulai behavior roaming
            
        }

        private void FixedUpdate()
        {
            // jalankan logic roaming tiap physics frame
            roaming.Checking();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                roaming.Start();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Die();
                roaming.Stop();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                roaming.Stop();
            }
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
