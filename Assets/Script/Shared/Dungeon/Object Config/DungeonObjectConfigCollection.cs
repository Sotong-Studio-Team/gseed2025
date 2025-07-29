using SotongStudio.SharedData.PredefinedData;
using SotongStudio.VContainer;
using UnityEngine;


namespace SotongStudio.Bomber
{
    public interface IDungeonObjectConfigCollection : IPredefinedCollection<IDungeonObjectConfig>
    {

    }

    [CreateAssetMenu(menuName = "Collection/Dungeon Object Config")]
    [RegisterAs(typeof(IDungeonObjectConfigCollection))]
    public class DungeonObjectConfigCollection : PredefinedCollection<DungeonObjectConfig, IDungeonObjectConfig>,
                                                 IDungeonObjectConfigCollection
    {

    }
}
