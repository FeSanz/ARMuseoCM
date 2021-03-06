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

    void Start()
    {
        aumentoTxt.SetText("X1");
        descripcionTxt.SetText(descripcionArray[numAumento-1]);
        disminuirBtn.interactable = false;
        disminuirBtn.gameObject.SetActive(false);
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
            disminuirBtn.gameObject.SetActive(true);
        }
        if(numAumento == videosArray.Length)
        {
            aumentoBtn.interactable = false;
            aumentoBtn.gameObject.SetActive(false);
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
            aumentoBtn.gameObject.SetActive(true);
        }
        if (numAumento == 1)
        {
            disminuirBtn.interactable = false;
            disminuirBtn.gameObject.SetActive(false);
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
}
