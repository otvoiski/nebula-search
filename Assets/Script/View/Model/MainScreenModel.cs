using UnityEngine;

namespace Assets.Script.View.Model
{
    public class MainScreenModel : MonoBehaviour
    {
        public Transform BottomBar { get; set; }
        public Transform Toast { get; set; }
        public InterfaceMenuModel InterfaceMenu { get; set; }
        public BuildScreenModel BuildScreen { get; set; }
    }
}