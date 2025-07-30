using NavMeshPlus.Components;
using NavMeshPlus.Extensions;
using UnityEngine;

namespace SotongStudio
{
    public class NavMeshUpdater : MonoBehaviour

    {
        [SerializeField] private CollectSourcesCache2d _collectSourcesCache2d;
        [SerializeField] private NavMeshSurface _navigationSurface;

        private void Start()
        {
            _navigationSurface.BuildNavMesh();
        }
        public void Update()
        {
            _navigationSurface.UpdateNavMesh(_navigationSurface.navMeshData);
            if (_collectSourcesCache2d.IsDirty)
            {
                _collectSourcesCache2d.UpdateNavMesh();
            }
        }
    }
}
