using Assets.Data.Enum;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Data.Util.Toast
{
    public class ToastControl : MonoBehaviour
    {
        private const int Title = 0;
        private const int Value = 1;
        private const int Icon = 2;

        private const float WarningTime = 5f;
        private const float SuccessTime = 5f;
        private const float ErrorTime = 5f;
        private const float InfoTime = 5f;
        private const float DefaultTime = 5f;

        private ToastType _type;
        private float _warning;
        private float _success;
        private float _error;
        private float _info;

        private void Start()
        {
            if (name.Contains($"{ ToastType.Warning }")) _type = ToastType.Warning;
            if (name.Contains($"{ ToastType.Success }")) _type = ToastType.Success;
            if (name.Contains($"{ ToastType.Error }")) _type = ToastType.Error;
            if (name.Contains($"{ ToastType.Info }")) _type = ToastType.Info;
        }

        private void Update()
        {
            switch (_type)
            {
                case ToastType.Warning:
                    if (WaitForSecond(WarningTime, ref _warning))
                        Destroy(gameObject);
                    break;

                case ToastType.Success:
                    if (WaitForSecond(SuccessTime, ref _success))
                        Destroy(gameObject);
                    break;

                case ToastType.Error:
                    if (WaitForSecond(ErrorTime, ref _error))
                        Destroy(gameObject);
                    break;

                case ToastType.Info:
                    if (WaitForSecond(InfoTime, ref _info))
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