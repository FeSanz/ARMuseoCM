using System.Collections;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField, Tooltip("Objeto al que se tomará como centro de la translación")] 
    public Transform rotationCenter;
    [SerializeField, Tooltip("Altura a la que el satélite va a rotar")]
    public float rotationRadius = 0.2f;
    [SerializeField, Tooltip("Velocidad del satélite")]
    public float angularSpeed = 1f;
    [SerializeField, Tooltip("Canvas en el que se va a desplegar la información")] 
    public GameObject canvasAgua;

    private float posX = 0, posY = 0, posZ, angle = 0;
    private bool completada = false;

    /// <summary>
    ///     Funcion que mueve el satelite al rededor del planeta
    /// </summary>
    /// <returns></returns>
    void Update()
    {
        //Mientras no se hayan dado 3 vueltas el satélite sigue moviéndose
        if (!completada)
        {
            //posX = rotationCenter.transform.localPosition.x + Mathf.Cos(angle) * rotationRadius;
            posY = rotationCenter.transform.localPosition.y + Mathf.Sin(angle) * rotationRadius;
            posZ = rotationCenter.transform.localPosition.z + Mathf.Cos(angle) * rotationRadius;

            transform.localPosition = new Vector3(posX, posY, posZ);
            angle += Time.deltaTime * angularSpeed;
        }

        //Si el satelite ya dio 3 vueltas (aprox. 7 grados por vuelta) mostramos la imagen del agua
        if (angle >=21f)
        {
            angle = 0f;
            completada = true;
            canvasAgua.SetActive(true);
            StartCoroutine(MuestraAgua());
        }
    }

    /// <summary>
    ///     Funcion que detiene la imagen del agua durante 10 segundos
    /// </summary>
    /// <returns></returns>
    private IEnumerator MuestraAgua()
    {
        yield return new WaitForSeconds(10);
        canvasAgua.SetActive(false);
        completada = false;
    }

    /// <summary>
    ///     Funcion que detiene la corrutina que muestra la imagen del agua
    /// </summary>
    /// <returns></returns>
    public void ParaCorrutina()
    {
        StopCoroutine(MuestraAgua());
        canvasAgua.SetActive(false);
        completada = false;
    }
}