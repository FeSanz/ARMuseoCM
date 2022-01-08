using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField, Tooltip("Objetos de audio")] 
    private GameObject StageNext;
    
    [SerializeField, Tooltip("Objetos de audio")] 
    private float Wait = 15;

    IEnumerator AudioSecuence()
    {
        yield return new WaitForSeconds(Wait);
        StageNext.SetActive(true);
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        StartCoroutine(AudioSecuence());
    }
}
