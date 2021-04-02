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
                var t = PrintOnConsole(text);
                t.text = $"You dont said nothing!";
                t.color = Color.red;

                return false;
            }
            else
            {
                PrintOnConsole(text).text = $"You said: {text}";
                return true;
            }
        }
    }
}