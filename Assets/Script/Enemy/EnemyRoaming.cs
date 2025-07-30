using System.Collections.Generic;
using UnityEngine;

namespace SotongStudio.Bomber
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class EnemyRoaming : MonoBehaviour
    {
        [Header("Enemy Data")]
        public Enemy enemyData = new Enemy();

        [Header("Roaming")]
        public LayerMask obstacleLayers;      // layer untuk tembok ( " WALL " )
        public float safeDistance = 0.2f;     // jarak aman biar ga dempet
        public float checkDistance = 0.5f;    // jarak cek raycast

        private Rigidbody2D rb;
        private Collider2D col;
        private Vector2 currentDir;

        
        private static readonly Vector2[] ORTHO_DIRS = new Vector2[]
        {
            Vector2.up, Vector2.down, Vector2.left, Vector2.right
        };

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            col = GetComponent<Collider2D>();

            // memastikan gscalenya 0
            rb.gravityScale = 0;

            // Freze Rotate
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        private void Start()
        {
            // pilih arah gerakan awal secara acak
            currentDir = ORTHO_DIRS[Random.Range(0, ORTHO_DIRS.Length)];
        }

        private void FixedUpdate()
        {
            // Cek apakah ada tembok di depan
            if (IsBlocked(currentDir))
            {
                // Jika ada berhenti dan gerak ke lain arah
                rb.linearVelocity = Vector2.zero;
                ChooseNewDirection();
            }
            else
            {
                // lanjut jjalan
                rb.linearVelocity = currentDir * enemyData.moveSpeed;
            }
        }
        
        // pilih arah baru yang tidak terhalang 
        private void ChooseNewDirection()
        {
            List<Vector2> candidates = new List<Vector2>();

            // cek arah ortogonal
            foreach (var dir in ORTHO_DIRS)
            {
                // delay
                if (dir == -currentDir) continue;
                if (!IsBlocked(dir))
                {
                    candidates.Add(dir);
                }
            }

            // kalau semua arah gabisa, maka puter balik
            if (candidates.Count == 0)
            {
                foreach (var dir in ORTHO_DIRS)
                {
                    if (!IsBlocked(dir))
                        candidates.Add(dir);
                }
            }

            // pilih satu arah acak
            if (candidates.Count > 0)
            {
                currentDir = candidates[Random.Range(0, candidates.Count)];
            }
        }
        
        // cek apakah ada penghalang?
        private bool IsBlocked(Vector2 dir)
        {
            // tambahin safeDistance untuk menjaga jarak aman
            Vector2 origin = (Vector2)transform.position + dir * safeDistance;
            RaycastHit2D hit = Physics2D.Raycast(origin, dir, checkDistance, obstacleLayers);
            return hit.collider != null;
        }
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            if (col != null)
            {
                Gizmos.DrawLine(transform.position, transform.position + (Vector3)currentDir * checkDistance);
            }
        }
    }
}
