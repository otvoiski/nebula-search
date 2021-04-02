using System;
using UnityEngine;

namespace Assets.Data.Util
{
    public class TimerRun
    {
        public float timer;

        [Obsolete]
        public float Run()
        {
            timer += Time.deltaTime;
            return (timer % 60);
        }

        public static bool Run(float wait, ref float timer)
        {
            timer += Time.deltaTime;
            if ((timer % 60) >= wait)
            {
                timer = 0;
                return true;
            }
            else return false;
        }

        public void Reset() => timer = 0;
    }
}