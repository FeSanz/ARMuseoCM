using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MicroscopioController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI aumentoTxt;
    [SerializeField] TextMeshProUGUI descripcionTxt;
    [SerializeField, Tooltip("Reproductor de video")]
    public VideoPlayer videoPlayer;
    [SerializeField, Tooltip("Lista de videos")]
    public VideoClip[] videosArray;
    [SerializeField, Tooltip("Lista de descripciones de los videos")]
    public string[] descripcionArray;
    [SerializeField, Tooltip("Lista de audios")]
    public GameObject[] audios;
    private int numAumento = 1;
    [SerializeField, Tooltip("Boton para el aumento de zoom")]
    public Button aumentoBtn;
    [SerializeField, Tooltip("Boton para el disminución de zoom")] 
    public Button disminuirBtn;
    [SerializeField, Tooltip("Notificacion para aumentar volumen tipo SnackBar")]
    private GameObject SnackBar;

    void Start()
    {
        aumentoTxt.SetText("X1");
        descripcionTxt.SetText(descripcionArray[numAumento-1]);
        disminuirBtn.interactable = false;
    }

    void Update()
    {
        if (AudioSettings.Mobile.muteState)
        {
            SnackBar.SetActive(true);
        }
        else
        {
            SnackBar.SetActive(false);
        }
    }

    /// <summary>
    ///     Funcion que cambia al nivel de zoom siguiente
    /// </summary>
    public void Aumentar()
    {
        OcultarAudios();
        if (numAumento < videosArray.Length)
        {
            numAumento++;
            aumentoTxt.SetText("X" + (numAumento));
            descripcionTxt.SetText(descripcionArray[numAumento - 1]);
            videoPlayer.clip = videosArray[numAumento - 1];
            audios[numAumento - 1].SetActive(true);
            PlayAudio();
            disminuirBtn.interactable = true;
        }
        if(numAumento == videosArray.Length)
        {
            aumentoBtn.interactable = false;
        }
    }

    /// <summary>
    ///     Funcion que cambia al nivel de zoom anterior
    /// </summary>
    public void Disminuir()
    {
        OcultarAudios();
        if (numAumento > 1)
        {
            numAumento--;
            aumentoTxt.SetText("X" + (numAumento));
            descripcionTxt.SetText(descripcionArray[numAumento - 1]);
            videoPlayer.clip = videosArray[numAumento - 1];
            audios[numAumento - 1].SetActive(true);
            PlayAudio();
            aumentoBtn.interactable = true;
        }
        if (numAumento == 1)
        {
            disminuirBtn.interactable = false;
        }
    }

    private void OcultarAudios()
    {
        foreach (GameObject audio in audios)
        {
            audio.SetActive(false);
        }
    }

    public void PauseAudio()
    {
        audios[numAumento-1].GetComponent<AudioSource>().Pause();
    }

    public void PlayAudio()
    {
        audios[numAumento-1].GetComponent<AudioSource>().Play();
    }
    
    public void MuteAudioAll()
    {
        foreach (GameObject audio in audios)
        {
            audio.GetComponent<AudioSource>().mute = true;
        }
    }

    public void UnMuteAudioAll()
    {
        foreach (GameObject audio in audios)
        {
            audio.GetComponent<AudioSource>().mute = false;
        }
    }
}
