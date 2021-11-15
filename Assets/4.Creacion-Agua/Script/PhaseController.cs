using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseController : MonoBehaviour
{
    [SerializeField, Tooltip("Audios de cada etapa")]
    private AudioSource[] AudioStage;
    
    [SerializeField, Tooltip("Velocidad de aparicion de cada shader en transisición")]
    private float Increase = 0.005f;

    private float[] _stageValue = {1, 0, 0, 0};
    private Material _materialEarth;

    void Start()
    {
        _materialEarth = GetComponent<Renderer>().material;
    }
    IEnumerator StageController()
    {
        AudioStage[0].Play();
        yield return new WaitForSeconds (2);

        AudioStage[1].Play();
        while (_stageValue[0] >= 0)
        {
            _stageValue[0] -= Increase;
            _materialEarth.SetFloat("FloatState", _stageValue[0]); 
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds (2);
        

        AudioStage[2].Play();
        while (_stageValue[1] <= 1)
        {
            _stageValue[1] += Increase;
            _materialEarth.SetFloat("FloatPangea", _stageValue[1]); 
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds (2);


        AudioStage[3].Play();
        while (_stageValue[2] <= 1)
        {
            _stageValue[2] += Increase;
            _materialEarth.SetFloat("FloatEarth", _stageValue[2]); 
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void StartStage()
    {
        StartCoroutine(StageController());
    }
}
