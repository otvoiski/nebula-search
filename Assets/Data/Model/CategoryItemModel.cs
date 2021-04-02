using Assets.Data.Enum;
using UnityEngine;
using Material = Assets.Data.Enum.Material;

namespace Assets.Data.Model
{
    public abstract class CategoryItemModel : ScriptableObject
    {
        public string Title;
        public CategoryItemEnum Categoy;
        public Sprite Icon;
        public Material[] Inputs;
        public Material[] Outputs;
    }
}