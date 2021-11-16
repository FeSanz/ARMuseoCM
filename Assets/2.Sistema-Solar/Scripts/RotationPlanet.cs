using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPlanet : MonoBehaviour
{
    [SerializeField, Tooltip("Velocidad de rotacion")]
    private float speed = 20.0f;

    void Update()
    {
        transform.RotateAround (transform.position, Vector3.up ,  speed * Time.deltaTime );
        //transform.localRotation = Quaternion.Euler(0,0, speed * Time.deltaTime);
    }
}
