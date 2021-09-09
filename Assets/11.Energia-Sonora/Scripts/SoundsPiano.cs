using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsPiano : MonoBehaviour
{
    [SerializeField] AudioClip[] audios;
    [SerializeField] ParticleSystem waves;
    AudioSource audioSource;
    bool reproducing = false;
    int numberAudio = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        //print(audios.Length);
        waves.Stop();

    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            waves.Stop();
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                //print(hit.collider.tag);
                if (hit.collider.tag == "piano")
                {
                    waves.Play();
                    NextAudio();
                    if (audioSource.isPlaying)
                    {
                        //reproducing = false;
                        audioSource.Stop();
                    }
                    else
                    {
                        //reproducing = true;
                        audioSource.Play();
                    }
                }

            }
                    //hit.collider.enabled = false;


        }
    }

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
