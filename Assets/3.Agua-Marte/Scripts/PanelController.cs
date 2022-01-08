using TMPro;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField, Tooltip("Titulo del panel")]
    public TextMeshProUGUI titulo;
    [SerializeField, Tooltip("Descripcion del planeta")]
    public TextMeshProUGUI descripcion;
    [SerializeField, Tooltip("Temperatura del planeta")]
    public TextMeshProUGUI temperatura;
    [SerializeField, Tooltip("Radio del planeta")]
    public TextMeshProUGUI radio;
    [SerializeField, Tooltip("Lista de titulos del panel")]
    public string[] titulos;
    [SerializeField, Tooltip("Lista de descripciones de los planetas")]
    public string[] descripciones;
    [SerializeField, Tooltip("Lista de temperaturas de los planetas")]
    public string[] temperaturas;
    [SerializeField, Tooltip("Lista de los radios de los planetas")]
    public string[] radios;
    [SerializeField, Tooltip("Lista de planetas")]
    public GameObject[] planetas;

    private static int actual = 0;

    [SerializeField, Tooltip("Notificacion para aumentar volumen tipo SnackBar")]
    private GameObject SnackBar;

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

    /*
    private void Start()
    {
        PlayAudio();
    }
    */
    /// <summary>
    ///     Funcion que pone la descripcion de los planetas en el panel
    /// </summary>
    /// <returns></returns>
    public void PonerDescripcion(int posicion)
    {
        if (posicion != actual) { 
            titulo.SetText(titulos[posicion]);
            descripcion.SetText(descripciones[posicion]);
            temperatura.SetText(temperaturas[posicion]);
            radio.SetText(radios[posicion]);
            for (int i = 0; i < 4; i++)
            {
                planetas[i].SetActive(false);
            }
            planetas[posicion].SetActive(true);
            actual = posicion;
            PlayAudio();
        }
    }

    public void PauseAudio()
    {
        planetas[actual].GetComponent<AudioSource>().Pause();
        Debug.Log("actual pause" + actual);
    }

    public void PlayAudio()
    {
        planetas[actual].GetComponent<AudioSource>().Play();
        Debug.Log("actual play" + actual);
    }
    
    public void MuteAudioAll()
    {
        foreach (GameObject audio in planetas)
        {
            audio.GetComponent<AudioSource>().mute = true;
        }
    }

    public void UnMuteAudioAll()
    {
        foreach (GameObject audio in planetas)
        {
            audio.GetComponent<AudioSource>().mute = false;
        }
    }
}
