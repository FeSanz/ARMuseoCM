using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MicroscopioController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI aumentoTxt;
    [SerializeField] TextMeshProUGUI descripcionTxt;
    public VideoPlayer videoPlayer;
    public VideoClip[] videosArray;
    public string[] descripcionArray;
    private int numAumento = 1;
    [SerializeField] Button aumentoBtn;
    [SerializeField] Button disminuirBtn;

    void Start()
    {
        aumentoTxt.SetText("X1");
        descripcionTxt.SetText(descripcionArray[numAumento-1]);
        disminuirBtn.interactable = false;
    }

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
