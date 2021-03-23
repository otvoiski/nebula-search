using UnityEngine;

namespace Assets.Script.Data.Util.DeveloperConsole
{
    [CreateAssetMenu(fileName = "New Log Command", menuName = "DeveloperConsole/Commands/Log Command")]
    public class LogCommand : ConsoleCommand
    {
        public override bool Process(string[] args)
        {
            string logText = string.Join(" ", args);

            Debug.Log(logText);

            return true;
        }
    }
}