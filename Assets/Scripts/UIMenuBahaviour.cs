using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if PLATFORM_ANDROID
    using UnityEngine.Android;
#endif

public class UIMenuBahaviour : MonoBehaviour
{
    [SerializeField, Tooltip("GridLayout del menú de opciones")]
    private GridLayoutGroup _gridLayoutGroup;

    private void Awake()
    {
        foreach (string file in Directory.GetFiles("Assets", "Delete This File.txt", SearchOption.AllDirectories)) 
        {
            Debug.Log (file);
            // File.Delete(file);      
        }
    }

    void Start ()
    {
        #if PLATFORM_ANDROID
            StartCoroutine(AskForPermissions());
        #endif
    }

    void Update()
    {
        StartCoroutine(CheckForChangeOrientationScreen());
    }
    
    IEnumerator CheckForChangeOrientationScreen() {
        switch (Input.deviceOrientation) 
        {
            //No se puede determinar la orientación del dispositivo.
            case DeviceOrientation.Unknown:
                yield return null;
                break;
            //Dispositivo en posición vertical y botón de inicio en la parte inferior
            case DeviceOrientation.Portrait: 
                ConstraintColumCount(1);
                break;
            //Dispositivo en posición vertical y botón de inicio en la parte superior
            case DeviceOrientation.PortraitUpsideDown:
                ConstraintColumCount(1);
                break;
            //Dispositivo en posición horizontal y botón de inicio en el lado izquierdo
            case DeviceOrientation.LandscapeLeft:
                ConstraintColumCount(2);
                break;
            //Dispositivo en posición horizontal y botón de inicio en el lado derecho
            case DeviceOrientation.LandscapeRight:
                ConstraintColumCount(2);
                break;
            default:
                yield return null;
                break;
        }
    }

    /// <summary>
    /// Establece el tipo de limitación de layout
    /// </summary>
    /// <param name="count">Numero de columnas</param>
    private void ConstraintColumCount(int count)
    {
        _gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;  //Layout por columnas
        _gridLayoutGroup.constraintCount = count; //Numero de columnas
    }
    
    private IEnumerator AskForPermissions()
    {
        List<bool> permissions = new List<bool>() { false, false, false, false };
        List<bool> permissionsAsked = new List<bool>() { false, false, false, false };
        List<Action> actions = new List<Action>()
        {
            new Action(() => {
                permissions[0] = Permission.HasUserAuthorizedPermission(Permission.Microphone);
                if (!permissions[0] && !permissionsAsked[0])
                {
                    Permission.RequestUserPermission(Permission.Microphone);
                    permissionsAsked[0] = true;
                    return;
                }
            }),
            new Action(() => {
                permissions[1] = Permission.HasUserAuthorizedPermission(Permission.Camera);
                if (!permissions[1] && !permissionsAsked[1])
                {
                    Permission.RequestUserPermission(Permission.Camera);
                    permissionsAsked[1] = true;
                    return;
                }
            }),
            new Action(() => {
                permissions[2] = Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite);
                if (!permissions[2] && !permissionsAsked[2])
                {
                    Permission.RequestUserPermission(Permission.ExternalStorageWrite);
                    permissionsAsked[2] = true;
                    return;
                }
            }),
            new Action(() => {
                permissions[3] = Permission.HasUserAuthorizedPermission(Permission.ExternalStorageRead);
                if (!permissions[3] && !permissionsAsked[3])
                {
                    Permission.RequestUserPermission(Permission.ExternalStorageRead);
                    permissionsAsked[3] = true;
                    return;
                }
            })
        };
        for(int i = 0; i < permissionsAsked.Count; )
        {
            actions[i].Invoke();
            if(permissions[i])
            {
                ++i;
            }
            yield return new WaitForEndOfFrame();
        }
    }

    public void ExitOfApplication()
    {
        Application.Quit();
    }
}
