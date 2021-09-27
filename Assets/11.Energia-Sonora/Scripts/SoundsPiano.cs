using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsPiano : MonoBehaviour
{
    [Tooltip("Sistema de particulas de sonido")] [SerializeField] ParticleSystem waves;
    public float HighDown = 1.342f;
    private AudioSource audioSource; //Controlador de audio
    
    void Start()
    {
        waves.Stop();
    }
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "tecla")
                {
                    GameObject tecla = hit.collider.transform.gameObject;
                    tecla.transform.localPosition = new Vector3(1.017162f, HighDown, 0);
                    StartCoroutine(ReturnKeyPosition(tecla));
                    tecla.GetComponent<AudioSource>().Play();
                    waves.Play();

                }

            }
        }
    }

    /// <summary>
    /// Despues de .5 segundos regresa la tecla a su lugar
    /// </summary>
    private IEnumerator ReturnKeyPosition(GameObject Key)
    {
        // process pre-yield
        yield return new WaitForSeconds(.20f);
        Key.transform.localPosition = new Vector3(1.017162f, 1.52872f, 0);
        // process post-yield
    }
}
