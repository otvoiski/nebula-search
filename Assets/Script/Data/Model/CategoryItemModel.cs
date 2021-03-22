using Assets.Script.Data.Enum;
using UnityEngine;

namespace Assets.Script.Data.Model
{
    public abstract class CategoryItemModel : ScriptableObject
    {
        public string title;
        public CategoryItemEnum categoy;
        public Sprite icon;
        public Material[] inputs;
        public Material[] outputs;
    }
}