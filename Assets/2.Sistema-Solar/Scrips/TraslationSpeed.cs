using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraslationSpeed : MonoBehaviour
{
    [SerializeField, Tooltip("Animaciones de traslacion")] 
    private Animator[] TraslationAnim;
    
    [SerializeField, Tooltip("Velocidad traslacion")]
    private float speed;

    void Start()
    {
        TraslationAnim[0].speed = speed;
    }
}
