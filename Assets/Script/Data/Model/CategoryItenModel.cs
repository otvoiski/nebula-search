using Assets.Script.Data.Enum;
using UnityEngine;

namespace Assets.Script.Data.Model
{
    public abstract class CategoryItenModel : ScriptableObject
    {
        public string title;
        public CategoryItenEnum categoy;
        public Sprite icon;
        public Material[] inputs;
        public Material[] outputs;
    }
}