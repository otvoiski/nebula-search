using Assets.Data.Lib;
using System;
using Assets.Data.Enum;
using UnityEngine;

namespace Assets.Data.Util
{
    public class Toast : MonoBehaviour
    {
        public static void Exception(Exception ex)
        {
            Message(ToastType.Error, Locale.Translate["General"]["Exception"].ToString(), ex.Message);
        }

        public static void Message(ToastType toastType, string title, string message)
        {
            ToastControl toast = GetToast(toastType);

            toast.ShowToast(title: title, message: message);
        }

        private static ToastControl GetToast(ToastType toastType)
        {
            var toastBar = GameObject.FindWithTag("Toast");
            var toastResource = Resources.Load<GameObject>($"Toast/Toast-{toastType}");
            var toast = Instantiate(toastResource, toastBar.transform)
                .GetComponent<ToastControl>();
            toast.transform.SetParent(toastBar.transform);
            return toast;
        }
    }
}