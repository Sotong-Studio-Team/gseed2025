using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace SotongStudio.SharedData.PredefinedData
{
    public interface IPredefinedCollection<TValue> where TValue : IPredefinedItem
    {
        TValue GetItem(string itemId);
        IEnumerable<TValue> GetAllItems();
    }
    public abstract class PredefinedCollection<T,TValue> : ScriptableObject, IPredefinedCollection<TValue>
                                                            where T : ScriptableObject, TValue
                                                            where TValue : IPredefinedItem
    {

        [SerializeField] private List<T> _itemList = new List<T>();

        public TValue GetItem(string itemId)
        {
            var targetObject = _itemList.Find(data => data.ItemId == itemId);
            return targetObject;
        }

        public IEnumerable<TValue> GetAllItems()
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
