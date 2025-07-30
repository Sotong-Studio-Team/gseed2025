using SotongStudio.SharedData.PredefinedData;
using SotongStudio.VContainer;
using UnityEngine;

namespace SotongStudio.Bomber.Shared.Dungeon.Cluster
{
    public interface IClusterCollection : IPredefinedCollection<IClusterConfig>
    {
    }
    
    [CreateAssetMenu(menuName ="Collection/Cluster Config")]
    [RegisterAs(typeof(IClusterCollection))]
    public class ClusterCollection : PredefinedCollection<ClusterConfig, IClusterConfig>, 
                                     IClusterCollection
    {
    
    }
}
