using UnityEngine;

namespace Assets.Data.Model
{
    public class BuildScreenModel : MonoBehaviour
    {
        public Transform BuildMenu { get; set; }
        public Transform BuildList { get; set; }
        public Transform InfoScreen { get; set; }
        public GameObject SelectedItem { get; set; }
    }
}