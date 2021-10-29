using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class SolarSystemController : MonoBehaviour
{
    [SerializeField, Tooltip("Animaci�n del sistema solar")]
    private Animator animatorSolarSystem;
    
    //[SerializeField, Tooltip("Animaci�n del panel informativo")]
    //private Animator animatorInfoPanel;

    [SerializeField, Tooltip("Animaci�n de la notificaci�n")]
    private GameObject notificaci�n;

    [SerializeField, Tooltip("Lista de planetas a mostrar individualmente")]
    private GameObject[] listPlanets;
    
    [SerializeField, Tooltip("Titulo, Descripcion, D�as, A�os, Temperatura, Medidas")]
    private TextMeshProUGUI[] textData;

    /// <summary>
    /// Se activa al seleccionar un planeta para mostrar la descripci�n del mismo
    /// </summary>
    /// <param name="idPlanetSelected">ID del planeta seleccionado</param>
    public void ActivePlanets(int idPlanetSelected) 
    {
        if (notificaci�n.activeInHierarchy)
        {
            notificaci�n.GetComponent<Animator>().Play("Out");
            notificaci�n.SetActive(false);
        }
        switch (idPlanetSelected) {
            case 1:
                PlanetSelectedData( idPlanetSelected, "MERCURIO", 
                    "Es el planeta m�s peque�o del sistema solar y el m�s cercano al Sol",
                    "* Su rotaci�n dura 58.7 d�as", "* Su traslaci�n dura 88 d�as",
                    "* M�xima 427 �C \n* M�nima -183 �C","* Di�metro de \n4,879.4 km",
                    "* Distancia al sol\n57.91,000,000 km"
                    );
                break;
            case 2:
                PlanetSelectedData( idPlanetSelected, "VENUS", 
                    "Es el segundo planeta m�s cercano al Sol, su atmosfera est� compuesta por di�xido de carbono",
                    "* Su rotaci�n dura 243,018.7 d�as", "* Su traslaci�n dura 225 d�as",
                    "* M�xima 499.85 �C \n? M�nima -45.15  �C","* Di�metro de \n12, 103.6 km",
                    "* Distancia al sol\n108.2, 000, 000 km"
                );
                break;
            case 3:
                PlanetSelectedData( idPlanetSelected, "TIERRA", 
                    "Es el planeta m�s denso y uno de los m�s grande de los planetas rocosos, su atmosfera est� compuesta mayormente de nitr�geno y ox�geno",
                    "* Su rotaci�n dura 23h 56m 4.100s", "* Su traslaci�n 365.25 d�as",
                    "* M�xima 56.7 �C \n* M�nima -89.15 �C","* Di�metro de \n12,742 km",
                    "* Distancia al sol\n149.6,000,000 km"
                );
                break;
            case 4:
                PlanetSelectedData( idPlanetSelected, "MARTE", 
                    "Es conocido como el planeta rojo debido al �xido de hierro, predominante en su superficie",
                    "* Su rotaci�n dura 24.6229 horas", "* Su traslaci�n dura 687 d�as",
                    "* M�xima 20 �C \n* M�nima -87 �C","* Di�metro de \n679.4 km",
                    "* Distancia al sol\n227.9, 000, 000 km"
                );
                break;
            case 5:
                PlanetSelectedData( idPlanetSelected, "J�PITER", 
                    "Es el planeta m�s grande del sistema solar, y el primer planeta gigante gaseoso, es uno de los m�s brillantes en cielo nocturno",
                    "* Su rotaci�n dura 9h 55m 30s", "* Su traslaci�n dura 12 a�os",
                    "* M�xima -75.15 �C \n* M�nima -163.15 �C","* Di�metro de \n142,984 km",
                    "* Distancia al sol\n778.5,000,000 km"
                );
                break;
            case 6:
                PlanetSelectedData( idPlanetSelected, "SATURNO", 
                    "Es el �nico planeta con un sistema de anillos de hielo y roca visibles desde la Tierra",
                    "* Su rotaci�n dura 10h 33m 38s", "* Su traslaci�n dura 30 a�os",
                    "* M�xima -73� �C \n* M�nima -191.15 �C","* Di�metro de \n120,536 km",
                    "* Distancia al sol\n1,434 miles de millones de km"
                );
                break;
            case 7:
                PlanetSelectedData( idPlanetSelected, "URANO", 
                    " Es uno de los primeros planetas descubiertos por medio de un telescopio, tiene anillos tenues",
                    "* Su rotaci�n dura 17h 14m", "* Su traslaci�n dura 84 a�os",
                    "* M�xima -218.2 �C \n* M�nima -214.2 �C","* Di�metro de \n51.118km",
                    "* Distancia al sol\n2,871 miles de millones de km"
                );
                break;
            case 8:
                PlanetSelectedData( idPlanetSelected, "NEPTUNO", 
                    "Es denominado gigante helado debido a su lejan�a con el sol, su atm�sfera se compone de hidr�geno, helio y metano, es oscuro, fr�o y muy ventoso.",
                    "* Su rotaci�n dura 16h 6m 14s", "* Su traslaci�n dura 165 a�os",
                    "* M�xima -217.15 �C \n* M�nima -223 �C","* Di�metro de \n49.572 km",
                    "* Distancia al sol\n4,495 miles de millones de km"
                );
                break;
            case 9:
                PlanetSelectedData( idPlanetSelected, "SOL", 
                    "Estrella que se form� hace 5000 millones de a�os, su luz da vida, calor y mantiene unido el sistema solar",
                    "* Su rotaci�n dura 609 horas", "* Su traslaci�n dura 225 millones de a�os en la V�a L�ctea",
                    "* Temperatura del nucleo\n16,000,000 �C","* Di�metro de \n1,392.000 km",
                    "* Di�metro en el centro\n8.4m"
                );
                break;
            default:
                Debug.LogWarning("Opci�n no encontrada");
                break;
        }
    }

    /// <summary>
    /// Llena el panel de informaci�n de acuerdo al planeta seleccionado
    /// </summary>
    /// <param name="idPlanet"></param>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <param name="day"></param>
    /// <param name="year"></param>
    /// <param name="temperature"></param>
    /// <param name="measure"></param>
    private void PlanetSelectedData(int idPlanet, string name, string description, string day, string year, string temperature, string measure, string distance)
    {
        animatorSolarSystem.Play("AnimSolarSystemHide");
        HideAllPlanets();
        animatorSolarSystem.gameObject.SetActive(false);
        
        textData[0].text = name;
        textData[1].text = description;
        textData[2].text = day;
        textData[3].text = year;
        textData[4].text = temperature;
        textData[5].text = measure;
        textData[6].text = distance;
        
        listPlanets[idPlanet - 1].SetActive(true);
        if (idPlanet != 9)
        {
            listPlanets[idPlanet - 1].GetComponent<Animator>().SetTrigger("rotation");
        }
    }

    /// <summary>
    /// Oculta todos los planetas (lista)
    /// </summary>
    public void HideAllPlanets()
    {
        foreach(GameObject planet in listPlanets) 
        {
            planet.SetActive(false);
        }
    }
    
    /// <summary>
    /// Muestra nuevamente sistema solar y oculta planetas grandes
    /// </summary>
    public void ShowSolarSystem()
    {
        HideAllPlanets();
        animatorSolarSystem.gameObject.SetActive(true);
    }
}
