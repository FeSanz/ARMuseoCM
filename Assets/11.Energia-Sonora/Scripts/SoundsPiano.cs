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
                    waves.Play();

                }

            }
        }
    }
}
