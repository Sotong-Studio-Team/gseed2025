using SotongStudio.Utilities.AudioSystem;
using UnityEngine;

namespace SotongStudio.Bomber
{
    public class AnimatorSFXAudioPlayer : MonoBehaviour
    {
        public void PlaySFX(string sfxName)
        {
            BasicAudioSystem.Instance.PlaySFX(sfxName);
        }
    }
}
