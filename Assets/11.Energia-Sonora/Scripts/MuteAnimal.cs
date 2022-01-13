using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteAnimal : MonoBehaviour
{
    [SerializeField] AudioSource AudioToMute; 
    [SerializeField] GameObject Description;

    public void MuteAudio()
    {
        AudioToMute.enabled = false;
        Description.SetActive(true);
    }
    public void UnMuteAudio()
    {
        AudioToMute.enabled = true;
        Description.SetActive(false);
    }
}
