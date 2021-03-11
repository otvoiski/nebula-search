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
    private TimerRun timer;

    private void Start()
    {
        if (name.Contains($"{ ToastType.Warning }")) type = ToastType.Warning;
        if (name.Contains($"{ ToastType.Success }")) type = ToastType.Success;
        if (name.Contains($"{ ToastType.Error }")) type = ToastType.Error;
        if (name.Contains($"{ ToastType.Info }")) type = ToastType.Info;

        timer = new TimerRun();
    }

    private void Update()
    {
        switch (type)
        {
            case ToastType.Warning:
                if (WaitForSecond(WARNING_TIME))
                    Destroy(transform);
                break;

            case ToastType.Success:
                if (WaitForSecond(SUCCESS_TIME))
                    Destroy(this);
                break;

            case ToastType.Error:
                if (WaitForSecond(ERROR_TIME))
                    Destroy(gameObject);
                break;

            case ToastType.Info:
                if (WaitForSecond(INFO_TIME))
                    Destroy(this);
                break;

            default:
                Destroy(this);
                break;
        }
    }

    public bool WaitForSecond(float time)
    {
        while (timer.Run() <= time)
        {
            return false;
        }

        return true;
    }

    public void ShowToast(string title, string message)
    {
        transform.GetChild(TITLE).GetComponent<Text>().text = title;
        transform.GetChild(VALUE).GetComponent<Text>().text = message;
    }
}