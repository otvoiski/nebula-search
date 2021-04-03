using UnityEngine;
using UnityEngine.UI;

namespace Assets.Data.Util.DeveloperConsole
{
    public interface IConsoleCommand
    {
        string CommandWord { get; }

        bool Process(string[] args);
    }

    public abstract class ConsoleCommand : ScriptableObject, IConsoleCommand
    {
        [SerializeField] private string commandWord = string.Empty;

        public string CommandWord => commandWord;

        public abstract bool Process(string[] args);

        public static void PrintOnConsole(string text, Color color)
        {
            var scrollview = GameObject
                    .Find("VIEW HANDLER").transform
                    .Find("MainScreen").transform
                    .Find("DeveloperConsole").transform
                    .Find("Scroll View").transform;

            var context = scrollview
                    .Find("Viewport").transform
                    .Find("Content").transform;

            var item = Instantiate(
                Resources.Load<GameObject>("Prefabs/UI/MainScreen/DeveloperConsole/Scroll View/Viewport/Content/Text"),
                context);

            if (context.childCount > ViewHandler.LimitTextConsoleItem)
            {
                Destroy(context.GetChild(0).gameObject);
            }

            item.name = text.Length.ToString();

            var txt = item.GetComponent<Text>();

            txt.text = text;
            txt.color = color;

            Canvas.ForceUpdateCanvases();
            scrollview.GetComponent<ScrollRect>().verticalScrollbar.value = 0f;
            Canvas.ForceUpdateCanvases();
        }
    }
}