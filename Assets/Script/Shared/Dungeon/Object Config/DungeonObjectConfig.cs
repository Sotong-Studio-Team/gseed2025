using SotongStudio.SharedData.PredefinedData;
using UnityEngine;

namespace SotongStudio.Bomber
{
    public interface IDungeonObjectConfig : IPredefinedItem
    {
        public ushort ObjectCoverChance { get; }
        GameObject ObjectPrefab { get; }
    }
    [CreateAssetMenu(menuName ="Config/Dungeon Object", fileName ="DUN-OBJ-000")]
    public class DungeonObjectConfig : ScriptableObject, IDungeonObjectConfig
    {
        [SerializeField]
        private string _objectId;
        [SerializeField]
        private ushort _objectCoverRate;
        [SerializeField]
        private GameObject _objectPrefab;

        public string ItemId => _objectId;
        public ushort ObjectCoverChance => _objectCoverRate;
        public GameObject ObjectPrefab => _objectPrefab;

    }
}
