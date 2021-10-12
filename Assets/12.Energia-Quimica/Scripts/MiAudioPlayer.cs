using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MiAudioPlayer : MonoBehaviour
{
    public AudioSource reproductor;
    public AudioClip[] clips;
    public int boton;
    public float[] espera;


    /// <summary>
    /// Reproduce eol archivo de audio que se le pasa
    /// </summary>
    public void Play(int boton)
    {
        reproductor.clip = clips[boton];
        StartCoroutine(Await(espera[boton]));
    }

    IEnumerator Await(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        reproductor.Play();
    }
}
