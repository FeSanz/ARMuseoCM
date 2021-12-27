using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class SolarSystemController : MonoBehaviour
{
    [SerializeField, Tooltip("Animación del sistema solar")]
    private Animator animatorSolarSystem;

    [SerializeField, Tooltip("Animación de la notificación")]
    private GameObject notificacion;

    [SerializeField, Tooltip("Lista de planetas a mostrar individualmente")]
    private GameObject[] listPlanets;
    
    [SerializeField, Tooltip("Titulo, Descripcion, Días, Años, Temperatura, Medidas")]
    private TextMeshProUGUI[] textData;

    /// <summary>
    /// Se activa al seleccionar un planeta para mostrar la descripción del mismo
    /// </summary>
    /// <param name="idPlanetSelected">ID del planeta seleccionado</param>
    public void ActivePlanets(int idPlanetSelected) 
    {
        if (notificacion.activeInHierarchy)
        {
            notificacion.GetComponent<Animator>().Play("Out");
            notificacion.SetActive(false);
        }
        switch (idPlanetSelected) {
            case 1:
                PlanetSelectedData( idPlanetSelected, "MERCURIO", 
                    "Es el planeta más pequeño del sistema solar y el más cercano al Sol",
                    "* Su rotación dura 58.7 días", "* Su traslación dura 88 días",
                    "* Máxima 427 °C \n* Mínima -183 °C","* Diámetro de \n4,879.4 km",
                    "* Distancia al sol\n57,910,000 km"
                    );
                break;
            case 2:
                PlanetSelectedData( idPlanetSelected, "VENUS", 
                    "Es el segundo planeta más cercano al Sol, su atmosfera está compuesta por dióxido de carbono",
                    "* Su rotación dura 243,018.7 días", "* Su traslación dura 225 días",
                    "* Máxima 499.85 °C \n* Mínima -45.15  °C","* Diámetro de \n12,103.6 km",
                    "* Distancia al sol\n108,200,000 km"
                );
                break;
            case 3:
                PlanetSelectedData( idPlanetSelected, "TIERRA", 
                    "Es el planeta más denso y uno de los más grandes de los planetas rocosos, su atmosfera está compuesta mayormente de nitrógeno y oxígeno",
                    "* Su rotación dura 23h 56m 4.100s", "* Su traslación 365.25 días",
                    "* Máxima 56.7 °C \n* Mínima -89.15 °C","* Diámetro de \n12,742 km",
                    "* Distancia al sol\n149,600,000 km"
                );
                break;
            case 4:
                PlanetSelectedData( idPlanetSelected, "MARTE", 
                    "Es conocido como el planeta rojo debido al óxido de hierro, predominante en su superficie",
                    "* Su rotación dura 24.6229 horas", "* Su traslación dura 687 días",
                    "* Máxima 20 °C \n* Mínima -87 °C","* Diámetro de \n6,794 km",
                    "* Distancia al sol\n227,900,000 km"
                );
                break;
            case 5:
                PlanetSelectedData( idPlanetSelected, "JÚPITER", 
                    "Es el planeta más grande del sistema solar, y el primer planeta gigante gaseoso, es uno de los más brillantes en cielo nocturno",
                    "* Su rotación dura 9h 55m 30s", "* Su traslación dura 12 años",
                    "* Máxima -75.15 °C \n* Mínima -163.15 °C","* Diámetro de \n142,984 km",
                    "* Distancia al sol\n778,330,000 km"
                );
                break;
            case 6:
                PlanetSelectedData( idPlanetSelected, "SATURNO", 
                    "Es el único planeta con un sistema de anillos de hielo y roca visibles desde la Tierra",
                    "* Su rotación dura 10h 33m 38s", "* Su traslación dura 30 años",
                    "* Máxima -73° °C \n* Mínima -191.15 °C","* Diámetro de \n108,728 km",
                    "* Distancia al sol\n1,429,400,000 km"
                );
                break;
            case 7:
                PlanetSelectedData( idPlanetSelected, "URANO", 
                    " Es uno de los primeros planetas descubiertos por medio de un telescopio, tiene anillos tenues",
                    "* Su rotación dura 17h 14m", "* Su traslación dura 84 años",
                    "* Máxima -218.2 °C \n* Mínima -214.2 °C","* Diámetro de \n51,118 km",
                    "* Distancia al sol\n2,870,990,000 km"
                );
                break;
            case 8:
                PlanetSelectedData( idPlanetSelected, "NEPTUNO", 
                    "Es denominado gigante helado debido a su lejanía con el sol, su atmósfera se compone de hidrógeno, helio y metano, es oscuro, frío y muy ventoso.",
                    "* Su rotación dura 16h 6m 14s", "* Su traslación dura 165 años",
                    "* Máxima -217.15 °C \n* Mínima -223 °C","* Diámetro de \n49,532 km",
                    "* Distancia al sol\n4,504,300,000 km"
                );
                break;
            case 9:
                PlanetSelectedData( idPlanetSelected, "SOL", 
                    "Estrella que se formó hace 5000 millones de años, su luz da vida, calor y mantiene unido el sistema solar",
                    "* Su rotación dura 609 horas", "* Su traslación dura 225 millones de años en la Vía Láctea",
                    "* Temperatura del nucleo\n16,000,000 °C","* Diámetro de \n1,392,000 km",
                    "* Radio \n696,340 km"
                );
                break;
            default:
                Debug.LogWarning("Opción no encontrada");
                break;
        }
    }

    /// <summary>
    /// Llena el panel de información de acuerdo al planeta seleccionado
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
        animatorSolarSystem.Play("Hide");
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
