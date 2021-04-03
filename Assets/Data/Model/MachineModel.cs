using Assets.Data.Enum;
using System;
using System.Collections.Generic;
using UnityEngine;
using Material = Assets.Data.Enum.Material;

namespace Assets.Data.Model
{
    [CreateAssetMenu(fileName = "Machine", menuName = "Items/Machine")]
    public class MachineModel : ScriptableObject
    {
        public int MaxBuffer;
        public int Power;
        public int MaxProcessTime;
        public string Title;
        public CategoryItemEnum Category;
        public Sprite Icon;
        public GameObject Prefab;
        [TextArea] public string Description;
        [SerializeField] public List<ResourcesToBuildObject> _resourcesToBuildSize;
        public IDictionary<Material, int> ResourcesToBuild;
        public Material[] Inputs;
        public Material[] Outputs;

        [Serializable]
        public class ResourcesToBuildObject
        {
            public Material Key;
            public int Value;
        }

        public MachineModel()
        {
            _resourcesToBuildSize = new List<ResourcesToBuildObject>();
            ResourcesToBuild = new Dictionary<Material, int>();
            foreach (var entry in _resourcesToBuildSize)
            {
                ResourcesToBuild.Add(entry.Key, entry.Value);
            }
        }
    }
}