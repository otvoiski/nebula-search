using UnityEngine;

namespace Assets.Data.Util.DeveloperConsole
{
    [CreateAssetMenu(fileName = "New Log Command", menuName = "DeveloperConsole/Commands/Log Command")]
    public class LogCommand : ConsoleCommand
    {
        public override bool Process(string[] args)
        {
            string text = string.Join(" ", args);

            if (string.IsNullOrEmpty(text))
            {
                PrintOnConsole($"You dont said nothing!", Color.red);

                return false;
            }
            else
            {
                PrintOnConsole($"You said: {text}", Color.green);
                return true;
            }
        }
    }
}