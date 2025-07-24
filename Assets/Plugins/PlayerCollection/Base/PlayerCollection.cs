#nullable enable

using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

namespace SotongStudio.SharedData.PlayerCollection
{
    public interface IPlayerCollectionUpdate<T> where T : IPlayerCollectionItem
    {
        void UpdateItem(T item);
        void RemoveItem(string itemId);
    }

    public interface IPlayerCollection<T> where T : IPlayerCollectionItem
    {

        IEnumerable<T> GetAllData();
        T GetItem(string itemId);
        T this[string itemId] => GetItem(itemId);
    }
    public abstract class PlayerCollection<T> : IPlayerCollection<T>, IPlayerCollectionUpdate<T>
                    where T : IPlayerCollectionItem
    {
        protected abstract string CollectionName { get; }
        private Dictionary<string, T> _cachedCollectionItems = new();
        private const string _collectionNamePrefix = "Player";
        private string _playerPrefKey => string.Format("{0}_{1}", _collectionNamePrefix, CollectionName);

        private bool _IsReady;

        public T GetItem(string itemId)
        {
            var jsonString = PlayerPrefs.GetString(_playerPrefKey, string.Empty);
            var collection = JsonConvert.DeserializeObject<List<T>>(jsonString);

            if (collection == null) { throw new System.InvalidOperationException($"Cannot Find Collection {CollectionName}"); }

            var foundItem = collection.Find(item => item.ItemId == itemId);

            return foundItem;
        }

        public IEnumerable<T> GetAllData()
        {
            return _cachedCollectionItems?.Values ?? Enumerable.Empty<T>();
        }
        public void RemoveItem(string itemId)
        {
            _cachedCollectionItems.Remove(itemId);
            UpdateCachedCollection();
        }

        public void UpdateItem(T item)
        {
            if (_cachedCollectionItems != null)
            {
                _cachedCollectionItems[item.ItemId] = item;
                UpdateCachedCollection();
            }
        }

        private void UpdateCachedCollection()
        {
            if (_IsReady)
            {
                var jsonString = PlayerPrefs.GetString(_playerPrefKey, string.Empty);
                var getData = JsonConvert.DeserializeObject<List<T>>(jsonString);
                if (getData == null) { throw new System.InvalidOperationException($"Cannot Find Collection {CollectionName}"); }

                foreach (var loadData in getData)
                {
                    _cachedCollectionItems![loadData.ItemId] = loadData;
                }

                _IsReady = true;
            }

            var data = _cachedCollectionItems.Values.ToList();
            PlayerPrefs.SetString(_playerPrefKey, JsonConvert.SerializeObject(data));

        }
    }
}
