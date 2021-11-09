using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseController : MonoBehaviour
{
    [SerializeField, Tooltip("Prefabs de asteroides")]
    private Transform MeteoiritePrefab;

    [SerializeField, Tooltip("Tiempo de aparición de meteoritos")]
    private float timeBeetweenMeteorites = 0.50f;

    private int _currentMeteorites = 0;
    void Start () 
    {
        StartCoroutine (SpawnEnemies());
    }
    IEnumerator SpawnEnemies()//indicamos corutina
    {
        yield return new WaitForSeconds (2);//esperamos 2 segundos antes de mostrar meteoritos
        while(true)
        {
            if(_currentMeteorites <= 0)//no crees nada hasta que la oleada de enemigos previa se hayya eliminado
            {
                for(int i = 0; i< 3; i++)//enemigos leatorios si no hay enemigos creo 10 mas
                {
                    float randDistance = Random.Range (10, 25);//distancia de aparicion
                    Vector2 randDirection = Random.insideUnitCircle;//punto alazar de la circunferencia
                    Vector3 meteoritePos = transform.position;//posicion del gamecontroller (0,0,0)
                    meteoritePos.x += randDirection.x * randDistance;
                    meteoritePos.y += randDirection.y * randDistance;
                    Instantiate (MeteoiritePrefab, meteoritePos, transform.rotation);//instanciamos el enemigo en pantalla
                    _currentMeteorites++;
                    yield return new WaitForSeconds (timeBeetweenMeteorites);//corrutina dormida durante 0.25 seg

                }
            }
            yield return new WaitForSeconds (2.2f);//ya tengo enemigos y espero 2 seg mas

        }
    }
}
