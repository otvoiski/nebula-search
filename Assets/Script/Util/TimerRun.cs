using UnityEngine;

namespace Assets.Script.Util
{
    public class TimerRun
    {
        public float timer;

        public float Run()
        {
            timer += Time.deltaTime;
            return (timer % 60);
        }

        public void Reset() => timer = 0;
    }
}