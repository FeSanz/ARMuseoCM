using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControl : MonoBehaviour
{
    [SerializeField] GameObject nextArrow;
    public float tiempo_espera = 15;
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(ControlArrows());
    }

    IEnumerator ControlArrows()
    {
        yield return new WaitForSeconds(tiempo_espera);
        if (!nextArrow)
        {
            gameObject.SetActive(false);
        }
        nextArrow.SetActive(true);
        gameObject.SetActive(false);
    }
}
