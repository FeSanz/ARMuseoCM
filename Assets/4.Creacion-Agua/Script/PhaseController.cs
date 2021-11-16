using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PhaseController : MonoBehaviour
{
    [SerializeField, Tooltip("Audios de cada etapa")]
    private AudioSource[] AudioStage;
    
    [SerializeField, Tooltip("Meteoritos")]
    private GameObject[] Meteorito;
    
    [SerializeField, Tooltip("Velocidad de aparicion de cada shader en transisición")]
    private float speed = 0.5f;

    [SerializeField, Tooltip("Título de la etapa")]
    private TextMeshProUGUI titulo;
    
    [SerializeField, Tooltip("Descrpcion de la etapa")]
    private TextMeshProUGUI descripcion;

    private float _stageValue = 1;
    private Material _materialEarth;
    private int _stage = -1;

    void Start()
    {
        _materialEarth = GetComponent<Renderer>().material;
    }
    
    private void Update()
    {
        switch (_stage)
        {
            case 1:
                if (_stageValue >= 0)
                {
                    _stageValue -= Time.deltaTime * speed;
                    _materialEarth.SetFloat("FloatEarth", _stageValue);
                }
                break;
            case 2:
                if (_stageValue >= 0)
                {
                    _stageValue -= Time.deltaTime * speed;
                    _materialEarth.SetFloat("FloatState", _stageValue);
                }
                break;
            case 3:
                if (_stageValue <= 1)
                {
                    _stageValue += Time.deltaTime * speed;
                    _materialEarth.SetFloat("FloatPangea", _stageValue);
                }
                break;
            case 4:
                if (_stageValue <= 1)
                {
                    _stageValue += Time.deltaTime * speed;
                    _materialEarth.SetFloat("FloatEarth", _stageValue);
                }
                break;
            default:
                Debug.Log("Esperando estapa...");
                break;
        }
    }
    IEnumerator StageController()
    {
        AudioStage[0].Play();
        yield return new WaitForSeconds (12);
        
        //FloatEarth 1 - 0
        AudioStage[1].Play();
        StartCoroutine(ActiveMeteorite());
        _stageValue = 1;
        _stage = 1;
        titulo.text = "ETAPA 1";
        descripcion.text = "La temperatura de la tierra primitiva era demasiado alta, de tal manera que con ayuda del impacto de " +
                           "meteoritos y las erupciones volcánicas generaron explosiones que expulsaban vapor de agua";
        yield return new WaitForSeconds (16);
        
        //FloatState 1 - 0
        AudioStage[2].Play();
        _stageValue = 1;
        _stage = 2;
        titulo.text = "ETAPA 2";
        descripcion.text = "Al enfriarse la tierra el vapor de agua se fue condensando provocando numerosas lluvias, generando así los océanos";
        yield return new WaitForSeconds (10);
        
        //FloatPangea 0 - 1
        AudioStage[3].Play();
        _stageValue = 0;
        _stage = 3;
        titulo.text = "ETAPA 3";
        descripcion.text = "La superficie del agua acumulada en la Tierra se recicla a través de un ciclo permanente generando así lagos, ríos y manantiales";
        yield return new WaitForSeconds (11);
        
        //FloatEarth 0 - 1
        AudioStage[4].Play();
        _stageValue = 0;
        _stage = 4;
        titulo.text = "ETAPA 4";
        descripcion.text = "El agua en la tierra en la actualidad es necesaria para la formación de otras moléculas que son responsables del origen de la vida en la Tierra";
    }

    IEnumerator ActiveMeteorite()
    {
        Meteorito[0]. SetActive(true);
        yield return new WaitForSeconds (3);
        Meteorito[1]. SetActive(true);
        yield return new WaitForSeconds (3);
        Meteorito[2]. SetActive(true);
        yield return new WaitForSeconds (3);
        Meteorito[3]. SetActive(true);
        yield return new WaitForSeconds (3);
    }
    public void StartStage()
    {
        StartCoroutine(StageController());
    }
}
