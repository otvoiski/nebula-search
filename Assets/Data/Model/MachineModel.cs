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
        public List<ResourcesToBuildObject> ResourcesToBuild;
        public List<ResourcesToBuildObject> Inputs;
        public List<ResourcesToBuildObject> Outputs;

        [Serializable]
        public class ResourcesToBuildObject
        {
            public Material Material;
            public int Amount;
        }
    }
}