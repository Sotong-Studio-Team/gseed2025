using UnityEngine;

namespace SotongStudio.Bomber.Gameplay.DungeonObject.Enemy
{
    public interface IHunterEnemyVisual
    {
        void FlipVisualToRight(bool toRight);
    }
    public class HunterEnemyVisual : MonoBehaviour, IHunterEnemyVisual
    {
        [SerializeField]
        private GameObject _visual;

        [SerializeField]
        private Animator _animator;


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
