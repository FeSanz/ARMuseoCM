using TMPro;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public TextMeshProUGUI titulo;
    public TextMeshProUGUI descripcion;
    public TextMeshProUGUI temperatura;
    public TextMeshProUGUI radio;
    public string[] titulos;
    public string[] descripciones;
    public string[] temperaturas;
    public string[] radios;
    public GameObject[] planetas;

    private int actual = 0;

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
