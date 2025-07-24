using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace SotongStudio.SharedData.PredefinedData
{
    public abstract class PredefinedCollection<T> : ScriptableObject where T : ScriptableObject, IPredefinedItem
    {

        [SerializeField] private List<T> _itemList = new List<T>();

        public T GetItem(string itemId)
        {
            return _itemList.Find(data => data.ItemId == itemId);
        }

        public IEnumerable<T> GetAllItems()
        {
            return _itemList;
        }

        #region Get Data Helper
#if UNITY_EDITOR
        [Button]
        private void SearchItems()
        {
            var rawFilePath = UnityEditor.AssetDatabase.GetAssetPath(this).Split('/');
            string filePath = string.Empty;

            for (int i = 0; i < rawFilePath.Length - 1; i++)
            {
                filePath += rawFilePath[i] + "/";
            }
            string[] files = System.IO.Directory.GetFiles(filePath + "/", "*.asset", System.IO.SearchOption.AllDirectories);

            _itemList.Clear();
            foreach (var file in files)
            {
                var asset = UnityEditor.AssetDatabase.LoadAssetAtPath<T>(file);

                if (asset != null)
                    _itemList.Add((T)asset);

            }
        }
#endif


        #endregion
    }
}
