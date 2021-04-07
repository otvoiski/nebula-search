using System;
using Assets.Data.Enum;
using UnityEngine;

namespace Assets.Data.Util.Toast
{
    public class Toast : MonoBehaviour
    {
        public static void Exception(Exception ex)
        {
            ShowToast(ToastType.Error, Locale.Translate["General"]["Exception"].ToString(), ex.Message);
        }

        public static void ShowToast(ToastType toastType, string title, string message)
        {
            ToastControl toast = GetToast(toastType);

            toast.ShowToast(title: title, message: message);
        }

        private static ToastControl GetToast(ToastType toastType)
        {
            var transform = GameObject.FindGameObjectWithTag("Toast")
                .transform;

            var toastResource = Resources.Load<GameObject>($"Toast/Toast-{toastType}");
            var toast = Instantiate(toastResource, transform)
                .GetComponent<ToastControl>();
            toast.transform.SetParent(transform);
            return toast;
        }
    }
}