using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{

    private AudioSource audioS;
    [SerializeField] ParticleSystem Waves;
    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponentInChildren<AudioSource>();
    }


    public void PlayAudioSound()
    {
        audioS.Play();
    }

    public void PlayWaves()
    {
        Waves.Play();
    }
    public void StopWaves()
    {
        Waves.Stop();
    }

    public void HideWaves()
    {
        
    }


}
