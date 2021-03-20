using Assets.Script.Enumerator;
using Assets.Script.Util;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ToastControl : MonoBehaviour
{
    private const int TITLE = 0;
    private const int VALUE = 1;
    private const int ICON = 2;

    private const float WARNING_TIME = 2f;
    private const float SUCCESS_TIME = 2f;
    private const float ERROR_TIME = 2f;
    private const float INFO_TIME = 2f;
    private const float DEFAULT_TIME = 2f;

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
                if (WaitForSecond(WARNING_TIME, ref warning))
                    Destroy(gameObject);
                break;

            case ToastType.Success:
                if (WaitForSecond(SUCCESS_TIME, ref success))
                    Destroy(gameObject);
                break;

            case ToastType.Error:
                if (WaitForSecond(ERROR_TIME, ref error))
                    Destroy(gameObject);
                break;

            case ToastType.Info:
                if (WaitForSecond(INFO_TIME, ref info))
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
        transform.GetChild(TITLE).GetComponent<Text>().text = title;
        transform.GetChild(VALUE).GetComponent<Text>().text = message;
    }
}