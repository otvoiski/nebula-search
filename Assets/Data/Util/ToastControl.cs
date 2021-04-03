using Assets.Data.Enum;
using Assets.Data.Util;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Data.Lib
{
    public class ToastControl : MonoBehaviour
    {
        private const int Title = 0;
        private const int Value = 1;
        private const int Icon = 2;

        private const float WarningTime = 2f;
        private const float SuccessTime = 2f;
        private const float ErrorTime = 2f;
        private const float InfoTime = 2f;
        private const float DefaultTime = 2f;

        private ToastType type;
        private float warning;
        private float success;
        private float error;
        private float info;

        private void Start()
        {
            if (name.Contains($"{ ToastType.Warning }")) type = ToastType.Warning;
            if (name.Contains($"{ ToastType.Success }")) type = ToastType.Success;
            if (name.Contains($"{ ToastType.Error }")) type = ToastType.Error;
            if (name.Contains($"{ ToastType.Info }")) type = ToastType.Info;
        }

        private void Update()
        {
            switch (type)
            {
                case ToastType.Warning:
                    if (WaitForSecond(WarningTime, ref warning))
                        Destroy(gameObject);
                    break;

                case ToastType.Success:
                    if (WaitForSecond(SuccessTime, ref success))
                        Destroy(gameObject);
                    break;

                case ToastType.Error:
                    if (WaitForSecond(ErrorTime, ref error))
                        Destroy(gameObject);
                    break;

                case ToastType.Info:
                    if (WaitForSecond(InfoTime, ref info))
                        Destroy(gameObject);
                    break;

                default:
                    Destroy(this);
                    break;
            }
        }

        private bool WaitForSecond(float wait, ref float timer)
        {
            if (TimerRun.Run(wait, ref timer))
            {
                return true;
            }
            return false;
        }

        public void ShowToast(string title, string message)
        {
            transform.GetChild(Title).GetComponent<Text>().text = title;
            transform.GetChild(Value).GetComponent<Text>().text = message;
        }
    }
}