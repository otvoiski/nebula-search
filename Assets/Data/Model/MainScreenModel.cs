using UnityEngine;

namespace Assets.Data.Model
{
    public class MainScreenModel : MonoBehaviour
    {
        public Transform BottomBar { get; set; }
        public Transform Toast { get; set; }
        public BuildScreenModel BuildScreen { get; set; }
        public DeveloperConsoleModel DeveloperConsole { get; internal set; }
        public Transform MenuScreen { get; set; }
    }
}