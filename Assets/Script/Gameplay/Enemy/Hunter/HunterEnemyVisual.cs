using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.DungeonObject.Enemy
{
    public interface IHunterEnemyVisual
    {
        void FlipVisualToRight(bool toRight);
        GameObject GameObject { get; }
    }
    public class HunterEnemyVisual : MonoBehaviour, IHunterEnemyVisual
    {
        [SerializeField]
        private GameObject _visual;

        [SerializeField]
        private Animator _animator;

        public GameObject GameObject => gameObject;


        public void PlayWalkAnimation()
        {
            _animator.Play("Walk");
        }
        public void PlayIdleAnimation()
        {
            _animator.Play("Idle");
        }

        public void FlipVisualToRight(bool toRight)
        {
            _visual.transform.localScale = new Vector2(toRight ? -1 : 1, 1);
        }
    }
}
