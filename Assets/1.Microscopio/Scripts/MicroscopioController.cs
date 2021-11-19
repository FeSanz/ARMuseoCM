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
    private int numAumento = 1;
    [SerializeField, Tooltip("Boton para el aumento de zoom")]
    public Button aumentoBtn;
    [SerializeField, Tooltip("Boton para el diminicion de zoom")] 
    Button disminuirBtn;

    void Start()
    {
        aumentoTxt.SetText("X1");
        descripcionTxt.SetText(descripcionArray[numAumento-1]);
        disminuirBtn.interactable = false;
    }

    /// <summary>
    ///     Funcion que cambia al nivel de zoom siguiente
    /// </summary>
    public void Aumentar()
    {
        if (numAumento < videosArray.Length)
        {
            numAumento++;
            aumentoTxt.SetText("X" + (numAumento));
            descripcionTxt.SetText(descripcionArray[numAumento - 1]);
            videoPlayer.clip = videosArray[numAumento - 1];
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
        if (numAumento > 1)
        {
            numAumento--;
            aumentoTxt.SetText("X" + (numAumento));
            descripcionTxt.SetText(descripcionArray[numAumento - 1]);
            videoPlayer.clip = videosArray[numAumento - 1];
            aumentoBtn.interactable = true;
        }
        if (numAumento == 1)
        {
            disminuirBtn.interactable = false;
        }
    }
}
