using TMPro;
using UnityEngine;

namespace Assets.Script.Data.Util.DeveloperConsole
{
    public class DeveloperConsoleBehaviour : MonoBehaviour
    {
        [SerializeField] private string prefix = string.Empty;
        [SerializeField] private ConsoleCommand[] commands = new ConsoleCommand[0];

        [SerializeField] private TMP_InputField inputField = null;

        private static DeveloperConsoleBehaviour instance;
        private DeveloperConsole developerConsole;

        private DeveloperConsole DeveloperConsole
        {
            get
            {
                if (developerConsole != null) { return developerConsole; }
                return developerConsole = new DeveloperConsole(prefix, commands);
            }
        }

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
        }

        public void ProcessCommand(string inputValue)
        {
            DeveloperConsole.ProcessCommand(inputValue);

            inputField.text = string.Empty;
        }
    }
}