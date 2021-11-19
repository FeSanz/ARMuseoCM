using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class LagosRiosController : MonoBehaviour
{
    public GameObject[] modelosArray;
    private int numAumento = 1;
    [SerializeField, Tooltip("Boton para avanzar")] Button aumentoBtn;
    [SerializeField, Tooltip("Boton para retroceder")] Button disminuirBtn;

    void Start()
    {
        disminuirBtn.interactable = false;
    }

    /// <summary>
    /// Funcion para avanzar (cambiar modelo de rios o lagos)
    /// </summary>
    public void Aumentar()
    {
        OcultarModelos3D();
        if (numAumento < modelosArray.Length)
        {
            numAumento++;
            modelosArray[numAumento - 1].SetActive(true);
            disminuirBtn.interactable = true;
        }
        if(numAumento == modelosArray.Length)
        {
            aumentoBtn.interactable = false;
        }
    }
    
    /// <summary>
    /// Funcion para retroceder (cambiar modelo de rios o lagos)
    /// </summary>
    public void Disminuir()
    {
        OcultarModelos3D();
        if (numAumento > 1)
        {
            numAumento--;
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
        foreach(GameObject model in modelosArray)
        {
            model.SetActive(false);
        }
    }
}
