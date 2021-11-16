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

    void Update()
    {
        //Mientras no se hayan dado 3 vueltas el satélite sigue moviéndose
        if (!completada)
        {
            posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
            //posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius;
            posZ = rotationCenter.position.z + Mathf.Sin(angle) * rotationRadius;

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

    public void ParaCorrutina()
    {
        StopCoroutine(MuestraAgua());
        canvasAgua.SetActive(false);
        completada = false;
    }
}