using UnityEngine;

public class Rotador : MonoBehaviour
{
    [SerializeField, Tooltip("Planeta que se quiere rotar")]
    public GameObject planeta;

    [SerializeField, Tooltip("Velocidad a la que se movera en determinado eje")]
    public float velocidadX=0, velocidadY=0, velocidadZ=0;
    float anguloX=0, anguloY=0, anguloZ=0;
    [SerializeField, Tooltip("Sentido de la rotacion")]
    public bool wise;

    // Update is called once per frame
    void Update()
    {
        Rotacion(velocidadX, velocidadY, velocidadZ);
        //planeta.transform.eulerAngles =new Vector3(0, 0, angulo);
    }

    /// <summary>
    ///     Funncion que rota el planeta
    /// </summary>
    /// <param name="velocidadX">velocidad de giro en eje X</param>
    /// <param name="velocidadY">velocidad de giro en eje Y</param>
    /// <param name="velocidadZ">velocidad de giro en eje Z</param>
    public void Rotacion(float velocidadX, float velocidadY, float velocidadZ)
    {

        if (wise)
        {
            anguloX = velocidadX * Time.deltaTime;
            anguloY = velocidadY * Time.deltaTime;
            anguloZ = velocidadZ * Time.deltaTime;
        }
        else
        {
            anguloX = velocidadX * Time.deltaTime * -1;
            anguloY = velocidadY * Time.deltaTime * -1;
            anguloZ = velocidadZ * Time.deltaTime * -1;
        }
        planeta.transform.Rotate(new Vector3(anguloX, anguloY, anguloZ));
    }
}
