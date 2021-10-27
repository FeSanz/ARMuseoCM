using System.Collections;
using UnityEngine;

public class MoonOscillator : MonoBehaviour
{
    [SerializeField, Tooltip("Objeto al que se tomar� como centro de la translaci�n")] 
    public Transform rotationCenter;
    [SerializeField, Tooltip("Altura a la que el sat�lite va a rotar")]
    public float rotationRadius = 0.2f;
    [SerializeField, Tooltip("Velocidad del sat�lite")]
    public float angularSpeed = 1f;

    private float posX = 0, posY = 0, posZ, angle = 0;

    void Update()
    {
            posX = rotationCenter.localPosition.x + Mathf.Cos(angle) * rotationRadius;
            //posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius;
            posZ = rotationCenter.localPosition.z + Mathf.Sin(angle) * rotationRadius;

        //transform.localPosition = new Vector3(posX, posY, posZ);
        transform.localPosition = new Vector3(posX, posY, posZ);
        angle += Time.deltaTime * angularSpeed;
    }
}