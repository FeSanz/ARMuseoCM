using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsPiano : MonoBehaviour
{
    [Tooltip("Arreglo de audios para el piano")] [SerializeField] AudioClip[] audios;
    [Tooltip("Sistema de particulas de sonido")] [SerializeField] ParticleSystem waves;
    private AudioSource audioSource; //Controlador de audio
    private int numberAudio = 0; //variable para controlar el num de audios a reproducir
    
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        waves.Stop();
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "piano")
                {
                    waves.Play();
                    NextAudio();
                }

            }
        }
    }
     /// <summary>
     /// Método para hacer el cambio de audio, al llegar al final del areeglo re reinicia el orden
     /// </summary>
    public void NextAudio()
    {
        audioSource.clip = audios[numberAudio];
        if (audios.Length-1 == numberAudio)
        {
            numberAudio = 0;
        }else
            numberAudio++;
    }
}
