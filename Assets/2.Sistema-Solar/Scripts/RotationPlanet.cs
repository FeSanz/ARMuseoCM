using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPlanet : MonoBehaviour
{
    [SerializeField, Tooltip("Velocidad de rotacion")]
    private float speed = 20.0f;
    
    [SerializeField, Tooltip("Velocidad de rotacion")]
    private bool FlipRotation = false;
    void Update()
    {
        if (FlipRotation)
        {
            transform.RotateAround (transform.position, Vector3.down ,  speed * Time.deltaTime );
        }
        else
        {
            transform.RotateAround (transform.position, Vector3.up ,  speed * Time.deltaTime );
        }
   
    }
}
