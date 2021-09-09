using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Autofocus : MonoBehaviour
{
    void Start()

    {

        CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);

    }
}
