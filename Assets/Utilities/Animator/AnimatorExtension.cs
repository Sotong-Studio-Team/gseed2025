using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SotongStudio.Unlink.Utilities.AnimatorHelper
{
    public static class AnimatorExtension
    {
        public static UniTask PlayAsync(this Animator animator, CancellationToken cancellationToken)
        {
            var currentClip = animator.GetCurrentAnimatorClipInfo(0);
            var currentLenght = currentClip[0].clip.length;
            animator.Play(currentClip[0].clip.name);

            return UniTask.WaitForSeconds(currentLenght, cancellationToken: cancellationToken);
        }

        public static UniTask PlayAsync(this Animator animator, string stateName, CancellationToken cancellationToken)
        {
            var controllerClips = animator.runtimeAnimatorController.animationClips;
            var selectedClip = controllerClips.First(clip => clip.name == stateName);
            var currentLenght = selectedClip.length;
            animator.Play(stateName);

            return UniTask.WaitForSeconds(currentLenght, cancellationToken: cancellationToken);
        }
    }
}
