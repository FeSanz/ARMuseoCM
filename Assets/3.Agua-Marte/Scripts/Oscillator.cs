using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Oscillator : MonoBehaviour
{
    public Transform rotationCenter;
    public float rotationRadius = 0.2f, angularSpeed = 1f;

    float posX = 0, posY = 0, posZ, angle = 0;
    public float alturaX = 0, alturaY = 0, alturaZ = 0;
    //public TextMeshProUGUI valor;
    bool completada = false;
    public GameObject canvasAgua;

    void Update()
    {
        //Mientras no se hayan dado 3 vueltas sigue moviendose
        if (!completada)
        {
            posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
            //posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius;
            posZ = rotationCenter.position.z + Mathf.Sin(angle) * rotationRadius;

            transform.localPosition = new Vector3(posX + alturaX, posY + alturaY, posZ + alturaZ);
            angle = angle + Time.deltaTime * angularSpeed;
        }

        //Si el satelite ya dio 3 vueltas (aprox. 7 grados por vuelta) mostramos la imagen
        if (angle >=21f)
        {
            //if (angle >= 360f)
            angle = 0f;
            completada = true;
            canvasAgua.gameObject.SetActive(true);
            StartCoroutine(muestraAgua());
            
        }
        //valor.SetText(angle.ToString());
    }
   
    //FUncion que detiene la imagen del agua durante 8 segundos
    IEnumerator muestraAgua()
    {
        yield return new WaitForSeconds(8);
        canvasAgua.gameObject.SetActive(false);
        completada = false;
    }
}