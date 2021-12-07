using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenuBahaviour : MonoBehaviour
{
    [SerializeField, Tooltip("GridLayout del menú de opciones")]
    private GridLayoutGroup _gridLayoutGroup;

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

    public void ExitOfApplication()
    {
        Application.Quit();
    }
}
