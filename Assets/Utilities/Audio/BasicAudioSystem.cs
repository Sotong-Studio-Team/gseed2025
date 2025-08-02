using UnityEngine;

namespace SotongStudio.Utilities.AudioSystem
{
    public class BasicAudioSystem : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _bgmAudioSource;
        [SerializeField]
        private AudioSource _sfxAudioSource;

        [SerializeField]
        private AudioBank _audioBank;

        public static BasicAudioSystem Instance { get; private set; }
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }


        public void PlayBGM(string bgmName)
        {
            var clip = _audioBank.AudioMaps[bgmName];
            if (_bgmAudioSource != null && clip != null)
            {
                _bgmAudioSource.clip = clip;
                _bgmAudioSource.Play();
            }
        }
        public void PlaySFX(string sfxName)
        {
            var clip = _audioBank.AudioMaps[sfxName];

            if (_sfxAudioSource != null && clip != null)
            {
                _sfxAudioSource.PlayOneShot(clip);
            }
        }
    }
}
