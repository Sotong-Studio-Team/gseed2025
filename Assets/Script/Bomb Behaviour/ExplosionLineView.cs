using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace SotongStudio.Bomber
{
    public class ExplosionLineView : MonoBehaviour
    {
        public List<GameObject> _explosionPrefabs;    //0 middle, 1 extension, 2 end
        public int BombLength = 4;
        public float BombDuration = 1;
        public float ExplosionDuration = 0.5f;
        public GameObject Temp;
        public bool _isHitWall = false;

        private Collider2D _collider;

        private void Start()
        {
            _collider = GetComponent<Collider2D>();
        }

        public void HideBomb()
        {
            GetComponent<SpriteRenderer>().enabled = false;
            _collider.enabled = false;
        }

        public void ShowExplosion(int prefabIndex, Vector2 position, Vector3 rotationEuler)
        {
            Quaternion rotation = Quaternion.Euler(rotationEuler);
            Temp = Instantiate(_explosionPrefabs[prefabIndex], position, rotation, transform);
        }

        public void DestroyBomb()
        {
            Destroy(gameObject);
        }

        public void DetectWall(Vector2 direction, int distance)
        {
            Vector2 origin = transform.position;
            LayerMask layerMask = LayerMask.GetMask("Wall");

            RaycastHit2D hit = Physics2D.Raycast(origin, direction, distance, layerMask);

            if (hit.collider != null)
            {
                Debug.Log("Hit object: " + hit.collider.name);
                _isHitWall = true;
            }
        }
    }
}
