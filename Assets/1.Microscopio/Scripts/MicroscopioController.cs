using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MicroscopioController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI aumentoTxt;
    [SerializeField] Camera camaraMicroscopio;
    public GameObject[] AumentosArray;
    private int numAumento = 0;
    [SerializeField] Button aumentoBtn;
    [SerializeField] Button disminuirBtn;
    // Start is called before the first frame update
    void Start()
    {
        aumentoTxt.SetText("X1");
        disminuirBtn.interactable = false;
    }

    public void Aumentar()
    {
        if (numAumento < AumentosArray.Length-1)
        {
            numAumento++;
            aumentoTxt.SetText("X" + (numAumento + 1 ));
            camaraMicroscopio.fieldOfView = camaraMicroscopio.fieldOfView - 4;
            disminuirBtn.interactable = true;
            //AumentosArray[numAumento].SetActive(true);
        }
        if(numAumento == AumentosArray.Length - 1)
        {
            aumentoBtn.interactable = false;
        }
    }

    public void Disminuir()
    {
        if (numAumento > 0)
        {
            numAumento--;
            aumentoTxt.SetText("X" + (numAumento + 1));
            aumentoBtn.interactable = true;
            camaraMicroscopio.fieldOfView = camaraMicroscopio.fieldOfView + 4;
            //AumentosArray[numAumento].SetActive(true);
        }
        if (numAumento == 0)
        {
            disminuirBtn.interactable = false;
        }
    }
}
