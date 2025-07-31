using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SotongStudio.Bomber
{
    // Class biasa, bukan turunan MonoBehaviour
    public class EnemyRoaming
    {
        private readonly Transform transform;
        private readonly NavMeshAgent agent;
        private readonly Rigidbody2D rb;

        private readonly float moveSpeed;
        private readonly float navmeshCheckDistance;

        private Vector2 currentDirection;
        private bool isRoaming = false;

        private static readonly Vector2[] Directions =
        {
            Vector2.up, Vector2.down, Vector2.left, Vector2.right
        };

        public EnemyRoaming(Transform transform, NavMeshAgent agent, Rigidbody2D rb,
            float moveSpeed, float navmeshCheckDistance)
        {
            this.transform = transform;
            this.agent = agent;
            this.rb = rb;

            this.moveSpeed = moveSpeed;
            this.navmeshCheckDistance = navmeshCheckDistance;

            if (agent != null)
            {
                agent.updatePosition = false;
                agent.updateRotation = false;
            }

            currentDirection = GetRandomDirection();
        }

        public void Start()
        {
            isRoaming = true;
        }

        public void Stop()
        {
            isRoaming = false;
            rb.linearVelocity = Vector2.zero; // ✅ FIX
        }

        public void Checking()
        {
            if (!isRoaming)
            {
                rb.linearVelocity = Vector2.zero; // ✅ FIX
                return;
            }

            if (IsNearNavMeshEdge(currentDirection))
            {
                rb.linearVelocity = Vector2.zero; // ✅ FIX
                PickNewDirection();
            }
            else
            {
                rb.linearVelocity = currentDirection * moveSpeed; // ✅ FIX
            }
        }

        private Vector2 GetRandomDirection()
        {
            return Directions[Random.Range(0, Directions.Length)];
        }

        private void PickNewDirection()
        {
            List<Vector2> validDirections = new List<Vector2>();

            foreach (var dir in Directions)
            {
                if (dir == -currentDirection) continue;

                if (!IsNearNavMeshEdge(dir))
                    validDirections.Add(dir);
            }

            if (validDirections.Count == 0)
            {
                validDirections.AddRange(Directions); // fallback ke semua arah
            }

            currentDirection = validDirections[Random.Range(0, validDirections.Count)];
        }

        private bool IsNearNavMeshEdge(Vector2 dir)
        {
            if (agent == null) return false;

            Vector3 checkPos = transform.position + (Vector3)(dir * navmeshCheckDistance);
            return !NavMesh.SamplePosition(checkPos, out _, 0.5f, NavMesh.AllAreas);
        }

        public void DrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + (Vector3)currentDirection * navmeshCheckDistance);
        }
    }
}
