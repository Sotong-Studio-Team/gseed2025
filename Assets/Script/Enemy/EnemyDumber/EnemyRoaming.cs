using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SotongStudio.Bomber
{
    public class EnemyRoaming
    {
        private readonly Transform transform;
        private readonly NavMeshAgent agent;
        private readonly Rigidbody2D rb;
        
        private readonly LayerMask obstacleLayers;
        private readonly float moveSpeed;
        private readonly float safeDistance;
        private readonly float checkDistance;
        private readonly float navmeshCheckDistance;
        
        private Vector2 currentDirection;
        private bool isRoaming = false;
        
        private static readonly Vector2[] Directions =
        {
            Vector2.up, Vector2.down, Vector2.left, Vector2.right
        };

        // Konstruktor, dipanggil dari luar saat inisialisasi
        public EnemyRoaming(Transform transform, NavMeshAgent agent, Rigidbody2D rb, LayerMask obstacleLayers,
            float moveSpeed, float safeDistance, float checkDistance, float navmeshCheckDistance)
        {
            this.transform = transform;
            this.agent = agent;
            this.rb = rb;

            this.obstacleLayers = obstacleLayers;
            this.moveSpeed = moveSpeed;
            this.safeDistance = safeDistance;
            this.checkDistance = checkDistance;
            this.navmeshCheckDistance = navmeshCheckDistance;

            // Disable agent movement, hanya digunakan untuk deteksi navmesh
            if (agent != null)
            {
                agent.updatePosition = false;
                agent.updateRotation = false;
            }

            // pilih arah awal acak
            currentDirection = GetRandomDirection();
        }

        // mulai roaming
        public void Start()
        {
            isRoaming = true;
        }

        // berhenti roaming
        public void Stop()
        {
            isRoaming = false;
            rb.linearVelocity = Vector2.zero;
        }

        // dipanggil tiap FixedUpdate dari luar
        public void Checking()
        {
            if (!isRoaming)
            {
                rb.linearVelocity = Vector2.zero;
                return;
            }

            // Cek halangan atau ujung navmesh
            if (ShouldChangeDirection(currentDirection))
            {
                rb.linearVelocity = Vector2.zero;
                PickNewDirection();
            }
            else
            {
                rb.linearVelocity = currentDirection * moveSpeed;
            }
        }

        // ambil arah acak
        private Vector2 GetRandomDirection()
        {
            return Directions[Random.Range(0, Directions.Length)];
        }

        // butuh ganti arah?
        private bool ShouldChangeDirection(Vector2 dir)
        {
            return IsBlocked(dir) || IsNearNavMeshEdge(dir);
        }

        // memilih arah baru 
        private void PickNewDirection()
        {
            List<Vector2> validDirections = new List<Vector2>();

            foreach (var dir in Directions)
            {
                if (dir == -currentDirection) continue; // hindari balik arah langsung

                if (!IsBlocked(dir) && !IsNearNavMeshEdge(dir))
                    validDirections.Add(dir);
            }

            // jika tidak ada arah aman, ambil arah lain
            if (validDirections.Count == 0)
            {
                foreach (var dir in Directions)
                {
                    if (!IsBlocked(dir))
                        validDirections.Add(dir);
                }
            }

            if (validDirections.Count > 0)
                currentDirection = validDirections[Random.Range(0, validDirections.Count)];
        }

        // cek apakah arah ini ada penghalang 
        private bool IsBlocked(Vector2 dir)
        {
            Vector2 origin = (Vector2)transform.position + dir * safeDistance;
            RaycastHit2D hit = Physics2D.Raycast(origin, dir, checkDistance, obstacleLayers);
            return hit.collider != null;
        }

        // cek apakah di arah ini tidak ada navmesh lagi 
        private bool IsNearNavMeshEdge(Vector2 dir)
        {
            if (agent == null) return false;

            Vector3 checkPos = transform.position + (Vector3)(dir * navmeshCheckDistance);
            return !NavMesh.SamplePosition(checkPos, out _, 0.5f, NavMesh.AllAreas);
        }

        // debug visual
        public void DrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, transform.position + (Vector3)currentDirection * checkDistance);

            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + (Vector3)currentDirection * navmeshCheckDistance);
        }
    }
}
