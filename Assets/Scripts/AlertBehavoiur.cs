using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeadMosquito.IosGoodies;
using JetBrains.Annotations;

public class AlertBehavoiur : MonoBehaviour
{
    /// <summary>
    /// Muestra alertas tipo Toast unicamente para Android.
    /// </summary>
    /// <param name="message">Mensage a mostrar</param>
    public void AndroidAlertToast(string message)
    {
        #if UNITY_ANDROID
            //Crear objeto de la clase Toast
            AndroidJavaClass toastClass =new AndroidJavaClass("android.widget.Toast");

            //Crea arreglo para pasar parametros(activity-screen, mensaje, duración)
            object[] toastParams = new object[3];
            AndroidJavaClass unityActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            toastParams[0] = unityActivity.GetStatic<AndroidJavaObject>("currentActivity");
            toastParams[1] = message;
            toastParams[2] = toastClass.GetStatic<int>("LENGTH_LONG");

            //Llamar funcion estática de Toast y lanzar texto
            AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", toastParams);
            toastObject.Call("show");
        #else
            Debug.Log("Error. Alerta incompatible con su dispositivo");
        #endif
        
    }

    /// <summary>
    /// Muestra alerta para conformar unicamnte IOS
    /// </summary>
    /// <param name="header">Encabezado de la alerta</param>
    /// <param name="message">Mensaje a mostrar</param>
    [UsedImplicitly]
    public void iOSAlertConfirmation(string header, string message)
    {
        #if UNITY_IOS
            IGDialogs.ShowOneBtnDialog(header, message, "Confirmar", () => Debug.Log("iOS. Alerta cerrada!"));
        #else
            Debug.Log("Error. Alerta incompatible con su dispositivo");
        #endif
    }
}
