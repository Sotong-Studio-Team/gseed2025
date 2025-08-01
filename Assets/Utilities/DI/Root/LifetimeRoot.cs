using System.Collections.Generic;
using NaughtyAttributes;
using SotongStudio.SharedData.PlayerCollection;
using SotongStudio.SharedData.PredefinedData;
using SotongStudio.VContainer;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SotongStudio.Plugins.DI
{
    public class LifetimeRoot : LifetimeScope
    {
        [SerializeField] private ScriptableObject[] _registerdScriptableObjects;
        [SerializeField] private List<ScriptableObject> _predefinedCollection;
        [SerializeField] private MonoBehaviour[] _gameObject;
        protected override void Configure(IContainerBuilder builder)
        {
            InternalConfigure(builder);

            builder.RegisterPlayerCollection();
        }

        private void InternalConfigure(IContainerBuilder builder)
        {
            foreach (var data in _registerdScriptableObjects)
            {
                VContainerDIInstallerUtils.RegisterScriptable(builder, data);
            }
            foreach (var data in _predefinedCollection)
            {
                VContainerDIInstallerUtils.RegisterScriptable(builder, data);
            }

            VContainerDIInstallerUtils.RegisterMonoBehaviourComponents(builder, _gameObject);
        }

        #region Get Predefined Data Helper
#if UNITY_EDITOR
        private class SearchType : ScriptableObject, IPredefinedItem
        {
            public string ItemId => throw new System.NotImplementedException();
        }

        [Button]
        private void GetPredefineCollection()
        {
            var folderPath = Application.dataPath + "/Content/Predefined Collection";
            string[] files = System.IO.Directory.GetFiles(folderPath, "* Collection.asset", System.IO.SearchOption.AllDirectories);

            _predefinedCollection.Clear();
            foreach (var file in files)
            {
                var filePath = file.Substring(file.IndexOf("Asset"));
                Debug.Log(filePath);
                var asset = UnityEditor.AssetDatabase.LoadAssetAtPath<ScriptableObject>(filePath);

                if (asset != null)
                    _predefinedCollection.Add(asset);

            }
        }
#endif
        #endregion
    }
}
