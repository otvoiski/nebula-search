using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Script.Data.Util.DeveloperConsole
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

        public void PrintConsole(string log)
        {
            ListView myListView = new ListView();

            myListView.Q<ScrollView>().Query<Scroller>().ForEach(scroller =>
            {
                scroller.RegisterCallback<PointerDownEvent>((e) =>
                {
                    //set autoScroll to false
                }, TrickleDown.TrickleDown);
            });
        }
    }
}