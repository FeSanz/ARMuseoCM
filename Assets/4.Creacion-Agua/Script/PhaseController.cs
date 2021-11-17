using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhaseController : MonoBehaviour
{
    [SerializeField, Tooltip("Audios de cada etapa")]
    private AudioSource[] AudioStage;
    
    [SerializeField, Tooltip("Meteoritos")]
    private GameObject[] Meteorito;

    [SerializeField, Tooltip("Aureola de fuego")]
    private GameObject Halo;
    
    [SerializeField, Tooltip("Aureola de fuego")]
    private GameObject RestartButton;
    
    [SerializeField, Tooltip("Velocidad de aparicion de cada shader en transisición")]
    private float speed = 0.5f;

    [SerializeField, Tooltip("Título de la etapa")]
    private TextMeshProUGUI titulo;
    
    [SerializeField, Tooltip("Descripcion de la etapa")]
    private TextMeshProUGUI descripcion;
    
    [SerializeField, Tooltip("Notificación tipo SnackBar")]
    private GameObject SnackBar;

    private float _stageValue = 1;
    private Material _materialEarth;
    private int _stage = -1;

    private bool _targetFound = false;
    private bool _backScene = false;

    void Start()
    {
        _materialEarth = GetComponent<Renderer>().material;
    }
    
    private void Update()
    {
        if (AudioSettings.Mobile.muteState && _targetFound)
        {
            SnackBar.SetActive(true); 
        }
        else
        {
            SnackBar.SetActive(false);
        } 
        
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
        gameObject.GetComponent<LookAtCamera>().enabled = true;
        yield return new WaitForSeconds (1);
        Halo.SetActive(true);
        titulo.text = "ETAPA 1";
        descripcion.text = "La temperatura de la tierra primitiva era demasiado alta, de tal manera que con ayuda del impacto de " +
                           "meteoritos y las erupciones volcánicas generaron explosiones que expulsaban vapor de agua";
        yield return new WaitForSeconds (16);
        foreach (GameObject item in Meteorito)
        {
            item.SetActive(false);
        }
        Halo.SetActive(false);
        gameObject.GetComponent<LookAtCamera>().enabled = false;
        
        //FloatState 1 - 0
        AudioStage[2].Play();
        _stageValue = 1;
        _stage = 2;
        titulo.text = "ETAPA 2";
        descripcion.text = "Al enfriarse la tierra el vapor de agua se fue condensando provocando numerosas lluvias, generando así los océanos";
        yield return new WaitForSeconds (5);
        _stageValue = 0;
        _stage = 3;
        yield return new WaitForSeconds (5);
        
        //FloatPangea 0 - 1
        AudioStage[3].Play();
        titulo.text = "ETAPA 3";
        descripcion.text = "La superficie del agua acumulada en la Tierra se recicla a través de un ciclo permanente generando así lagos, ríos y manantiales";
        yield return new WaitForSeconds (6);
        _stageValue = 0;
        _stage = 4;
        yield return new WaitForSeconds (5);
        
        //FloatEarth 0 - 1
        AudioStage[4].Play();
        titulo.text = "ETAPA 4";
        descripcion.text = "El agua en la tierra en la actualidad es necesaria para la formación de otras moléculas que son responsables del origen de la vida en la Tierra";
        yield return new WaitForSeconds (14);
        RestartButton.SetActive(true);
    }

    IEnumerator ActiveMeteorite()
    {
        Meteorito[0]. SetActive(true);
        yield return new WaitForSeconds (4);
        Meteorito[1]. SetActive(true);
        yield return new WaitForSeconds (4);
        Meteorito[2]. SetActive(true);
        yield return new WaitForSeconds (4);
        Meteorito[3]. SetActive(true);
        yield return new WaitForSeconds (4);
    }
    public void StartStage()
    {
        _targetFound = true;
        StartCoroutine(StageController());
    }

    public void MuteAudio()
    {
        foreach (AudioSource audio in AudioStage)
        {
            audio.mute = true;
        }
    }
    
    public void SpeakAudio()
    {
        foreach (AudioSource audio in AudioStage)
        {
            audio.mute = false;
        }
    }

    public void ValidateBackScene()
    {
        _backScene = true;
        _targetFound = false;
        Debug.Log("MenuScene");
        SceneManager.LoadScene("MenuScene");
    }

    public void TargetLostAfterFound()
    {
        if (_targetFound && !_backScene)
        {
            _targetFound = false;
            Debug.Log("TargetLostAfterFound");
            SceneManager.LoadScene("CreacionAguaScene");
        }
    }

    public void ReloadScene()
    {
        _backScene = false;
        _targetFound = false;
        Debug.Log("Reload");
        SceneManager.LoadScene("CreacionAguaScene");
    }

    private void OnDisable()
    {
        Debug.Log("Disable");
    }
}
