using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace SotongStudio.Utilities.AudioSystem
{
    [CreateAssetMenu(fileName = "AudioBank", menuName = "Sotong Audio System/AudioBank")]
    public class AudioBank : ScriptableObject
    {
        [SerializeField]
        private List<AudioClip> _bgmClips;

        [SerializeField]
        private List<AudioClip> _sfxClips;

        private readonly Dictionary<string, AudioClip> _audioMaps = new Dictionary<string, AudioClip>();
        public Dictionary<string, AudioClip> AudioMaps
        {
            get
            {
                if (_audioMaps.Count != _bgmClips.Count + _sfxClips.Count)
                {
                    foreach (var bgm in _bgmClips)
                    {
                        _audioMaps.Add(bgm.name, bgm);
                    }

                    foreach (var sfx in _sfxClips)
                    {
                        _audioMaps.Add(sfx.name, sfx);
                    }
                }
                return _audioMaps;
            }
        }

        #region Get Data Helper
#if UNITY_EDITOR
        [SerializeField]
        private List<string> _audioFormat;

        [Button]
        private void SearchItems()
        {
            var rawFilePath = UnityEditor.AssetDatabase.GetAssetPath(this).Split('/');
            string filePath = string.Empty;

            List<string> fileFounds = new();

            foreach (var format in _audioFormat)
            {

                for (int i = 0; i < rawFilePath.Length - 1; i++)
                {
                    filePath += rawFilePath[i] + "/";
                }
                fileFounds.AddRange(System.IO.Directory.GetFiles(filePath, $"*.{format}", System.IO.SearchOption.AllDirectories));

            }
            _bgmClips.Clear();
            _sfxClips.Clear();

            foreach (var foundPath in fileFounds)
            {
                if (foundPath.Contains("BGM"))
                {
                    var asset = UnityEditor.AssetDatabase.LoadAssetAtPath<AudioClip>(foundPath);
                    
                    if (asset != null) _bgmClips.Add(asset);
                }
                else if (foundPath.Contains("SFX"))
                {
                    var asset = UnityEditor.AssetDatabase.LoadAssetAtPath<AudioClip>(foundPath);
                    if (asset != null) _sfxClips.Add(asset);
                }
            }
        }
#endif


        #endregion
    }
}
