using System.Collections;
using UnityEngine;

public class MoonOscillator : MonoBehaviour
{
    [SerializeField, Tooltip("Objeto al que se tomará como centro de la translación")] 
    public Transform rotationCenter;
    [SerializeField, Tooltip("Altura a la que el satélite va a rotar")]
    public float rotationRadius = 0.2f;
    [SerializeField, Tooltip("Velocidad del satélite")]
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