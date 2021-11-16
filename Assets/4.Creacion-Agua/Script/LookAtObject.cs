using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour
{
    [SerializeField, Tooltip("Objeto al que se direccionara")]
    private Transform ObjecttoLook;
    private void LateUpdate()
    {
        transform.LookAt(ObjecttoLook, transform.up);
    }
}
