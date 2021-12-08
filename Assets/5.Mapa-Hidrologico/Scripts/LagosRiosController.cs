using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class LagosRiosController : MonoBehaviour
{
    public GameObject[] modelosArray;
    private int numAumento = 1;
    [SerializeField, Tooltip("Boton para avanzar")] private Button aumentoBtn;
    [SerializeField, Tooltip("Boton para retroceder")] private Button disminuirBtn;
    [SerializeField, Tooltip("Notificación tipo SnackBar")] private GameObject SnackBar;

    void Start()
    {
        disminuirBtn.interactable = false;
        //modelosArray[0].GetComponent<AudioSource>().Play();
    }
    private void Update()
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
    public void MuteAudio()
    {
        foreach (GameObject audio in modelosArray)
        {
            audio.GetComponent<AudioSource>().mute = true;
        }
    }

    public void SpeakAudio()
    {
        foreach (GameObject audio in modelosArray)
        {
            audio.GetComponent<AudioSource>().mute = false;
        }
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
        PlayAudio();
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
        PlayAudio();
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

    public void PauseAudio()
    {
        modelosArray[numAumento - 1].GetComponent<AudioSource>().Pause();
    }
    public void PlayAudio()
    {
        modelosArray[numAumento - 1].GetComponent<AudioSource>().Play();
    }
}
