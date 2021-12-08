using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RotateScale : MonoBehaviour
{
    [SerializeField, Tooltip("Velocidad de rotacion")]
    private float speed = 20.0f;
    
    [SerializeField, Tooltip("Velocidad de rotacion")]
    private bool FlipRotation = false;

    [SerializeField, Tooltip("Slider")] 
    private Slider Slider;
    void Update()
    {
        if (FlipRotation)
        {
            transform.Rotate(Vector3.down ,  speed * Time.deltaTime );
        }
        else
        {
            transform.Rotate( Vector3.up ,  speed * Time.deltaTime );
        }
        
        print(Slider.value);
    }
}
