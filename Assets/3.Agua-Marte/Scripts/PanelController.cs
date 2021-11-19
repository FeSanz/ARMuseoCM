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
    private int actual = 0;

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
        }
    }
}
