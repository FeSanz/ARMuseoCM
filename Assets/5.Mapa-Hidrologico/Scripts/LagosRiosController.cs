using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class LagosRiosController : MonoBehaviour
{
    //[SerializeField] TextMeshProUGUI aumentoTxt;
    //[SerializeField] TextMeshProUGUI descripcionTxt;
    //public GameObject modelo;
    public GameObject[] modelosArray;
    //public string[] descripcionArray;
    private int numAumento = 1;
    [SerializeField] Button aumentoBtn;
    [SerializeField] Button disminuirBtn;

    void Start()
    {
        //aumentoTxt.SetText("X1");
        //descripcionTxt.SetText(descripcionArray[numAumento-1]);
        disminuirBtn.interactable = false;
    }

    public void Aumentar()
    {
        OcultarModelos3D();
        if (numAumento < modelosArray.Length)
        {
            numAumento++;
            //aumentoTxt.SetText("X" + (numAumento));
            //descripcionTxt.SetText(descripcionArray[numAumento - 1]);
            //modelos.clip = videosArray[numAumento - 1];
            modelosArray[numAumento - 1].SetActive(true);
            disminuirBtn.interactable = true;
        }
        if(numAumento == modelosArray.Length)
        {
            aumentoBtn.interactable = false;
        }
    }

    public void Disminuir()
    {
        OcultarModelos3D();
        if (numAumento > 1)
        {
            numAumento--;
            //aumentoTxt.SetText("X" + (numAumento));
            //descripcionTxt.SetText(descripcionArray[numAumento - 1]);
            //videoPlayer.clip = videosArray[numAumento - 1];
            modelosArray[numAumento - 1].SetActive(true);
            aumentoBtn.interactable = true;
        }
        if (numAumento == 1)
        {
            disminuirBtn.interactable = false;
        }
    }

    private void OcultarModelos3D()
    {
        foreach(GameObject model in modelosArray) {
            model.SetActive(false);
        }
    }
}
