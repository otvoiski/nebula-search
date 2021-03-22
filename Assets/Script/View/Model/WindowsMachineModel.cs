using UnityEngine;

namespace Assets.Script.View.Model
{
    public class WindowsMachineModel : MonoBehaviour
    {
        public Transform Title { get; set; }
        public Transform Inventory { get; set; }
        public Transform IO { get; set; }
        public Transform Button { get; set; }
        public Transform ProcessMenu { get; set; }
        public Transform Info { get; internal set; }
    }
}