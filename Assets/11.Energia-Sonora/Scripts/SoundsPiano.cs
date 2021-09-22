using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsPiano : MonoBehaviour
{
    [Tooltip("Arreglo de audios para el piano")] [SerializeField] AudioClip[] audios;
    [Tooltip("Sistema de particulas de sonido")] [SerializeField] ParticleSystem waves;
    public float HighDown = -0.08872f;
    private AudioSource audioSource; //Controlador de audio
    private int numberAudio = 0; //variable para controlar el num de audios a reproducir
    
    void Start()
    {
        //audioSource = gameObject.GetComponent<AudioSource>();
        //waves.Stop();
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
                    hit.collider.transform.localPosition = hit.collider.transform.localPosition + new Vector3(0, HighDown, 0);
                    StartCoroutine(ReturnKeyPosition(hit.collider.gameObject));
                    //waves.Play();
                    //NextAudio();
                }

            }
        }
    }
     /// <summary>
     /// M�todo para hacer el cambio de audio, al llegar al final del areeglo re reinicia el orden
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
