using UnityEngine;

public class Rotador : MonoBehaviour
{
    public GameObject planeta;
    public float velocidadX=0, velocidadY=0, velocidadZ=0;
    float anguloX=0, anguloY=0, anguloZ=0;

    // Update is called once per frame
    void Update()
    {
        Rotacion(velocidadX, velocidadY, velocidadZ);
        //planeta.transform.eulerAngles =new Vector3(0, 0, angulo);
    }

    public void Rotacion(float velocidadX, float velocidadY, float velocidadZ)
    {
        anguloX = velocidadX * Time.deltaTime;
        anguloY = velocidadY * Time.deltaTime;
        anguloZ = velocidadZ * Time.deltaTime;
        planeta.transform.Rotate(new Vector3(anguloX, anguloY, anguloZ));
    }
}
