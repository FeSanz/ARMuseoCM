using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class SolarSystemController : MonoBehaviour
{
    [SerializeField, Tooltip("Animación del sistema solar")]
    private Animator animatorSolarSystem;
    
    //[SerializeField, Tooltip("Animación del panel informativo")]
    //private Animator animatorInfoPanel;

    [SerializeField, Tooltip("Animación de la notificación")]
    private GameObject notificación;
    
    [SerializeField, Tooltip("Sistema de particulas del sol")]
    private ParticleSystem particleSun;

    [SerializeField, Tooltip("Lista de planetas a mostrar individualmente")]
    private GameObject[] listPlanets;
    
    [SerializeField, Tooltip("Titulo, Descripcion, Días, Años, Temperatura, Medidas")]
    private TextMeshProUGUI[] textData;

    void Start()
    {
        //Deshabilita colisionador de las particulas
        /*var collision = particleSun.GetComponent<ParticleSystem>().collision;
        collision.enabled = false;
        //Habilita loop
        var main = particleSun.GetComponent<ParticleSystem>().main;
        main.loop = true;*/
    }
    
    /// <summary>
    /// Se activa al seleccionar un planeta para mostrar la descripción del mismo
    /// </summary>
    /// <param name="idPlanetSelected">ID del planeta seleccionado</param>
    public void ActivePlanets(int idPlanetSelected) 
    {
        if (notificación.activeInHierarchy)
        {
            notificación.GetComponent<Animator>().Play("Out");
            notificación.SetActive(false);
        }
        switch (idPlanetSelected) {
            case 1:
                PlanetSelectedData( idPlanetSelected, "MERCURIO", 
                    "Es el planeta más pequeño de nuestro sistema solar, tiene una atmósfera poco densa.",
                    "* Su día dura 59 días terrestres", "* Su año dura 88 días terrestres",
                    "* Máxima 427 °C \n* Mínima -173 °C","* Diámetro de \n4,879.4 km"
                    );
                break;
            case 2:
                PlanetSelectedData( idPlanetSelected, "VENUS", 
                    "Su atmosfera está compuesta por dióxido de carbono, fue nombrada en honor a la diosa romana del amor",
                    "* Su día dura 243 días terrestres", "* Su año dura 225 días terrestres",
                    "* Máxima 499.85 °C \n? Mínima -45.15  °C","* Diámetro de \n12,104 km"
                );
                break;
            case 3:
                PlanetSelectedData( idPlanetSelected, "TIERRA", 
                    "Nuestro hogar, su atmosfera está compuesta mayormente de nitrógeno y oxígeno, superficie cubierta por 75% de agua",
                    "* Su día dura 24 horas", "* Su año dura 365.25 días",
                    "* Máxima 56.7 °C \n* Mínima -89.15 °C","* Diámetro de \n12.756 km"
                );
                break;
            case 4:
                PlanetSelectedData( idPlanetSelected, "MARTE", 
                    "Conocido como el planeta rojo, su atmosfera está compuesta mayormente de dióxido de carbono",
                    "* Su día dura 24.6 horas", "* Su año dura 687 días terrestres",
                    "* Máxima 20 °C \n* Mínima -140 °C","* Diámetro de \n6,779 km"
                );
                break;
            case 5:
                PlanetSelectedData( idPlanetSelected, "JÚPITER", 
                    "Planeta en estado gaseoso, es 1,300 veces más grande que la Tierra y es el más grande del sistema solar, 79 lunas confirmadas.",
                    "* Su día dura 10 horas", "* Su año dura 11.8 años terrestres",
                    "* Máxima 121 °C \n* Mínima -163 °C","* Diámetro de \n139,820 km"
                );
                break;
            case 6:
                PlanetSelectedData( idPlanetSelected, "SATURNO", 
                    "Segundo planeta más grande del sistema, es un planeta gaseoso, tiene anillos hechos de pedazos de hielo y roca.",
                    "* Su día dura 10.7 horas", "* Su año dura 29 años terrestres",
                    "* Máxima -130.15 °C \n* Mínima -191.15 °C","* Diámetro de \n116,460 km"
                );
                break;
            case 7:
                PlanetSelectedData( idPlanetSelected, "URANO", 
                    "Compuesto de agua, metano y amoniaco, tiene anillos tenues, su atmósfera está hecha de hidrógeno y helio.",
                    "* Su día dura 17 horas y 14 minutos", "* Su año dura 84 años terrestres",
                    "* Media -205 °C \n* Mínima -214.2 °C","* Diámetro de \n50,724 km"
                );
                break;
            case 8:
                PlanetSelectedData( idPlanetSelected, "NEPTUNO", 
                    "Su nombre es debido al dios griego de los mares Neptuno, su atmósfera se compone de hidrógeno, helio y metano, es oscuro, frío y muy ventoso.",
                    "* Su día dura 16 horas", "* Su año dura 164 años terrestres",
                    "* Máxima -217.15 °C \n* Media -220 °C","* Diámetro de \n49,244 km"
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
    private void PlanetSelectedData(int idPlanet, string name, string description, string day, string year, string temperature, string measure)
    {
        Debug.Log(idPlanet +". " + name);
        animatorSolarSystem.Play("AnimSolarSystemHide");
        //animatorInfoPanel.Play("Show");
        HideAllPlanets();
        animatorSolarSystem.gameObject.SetActive(false);
        
        textData[0].text = name;
        textData[1].text = description;
        textData[2].text = day;
        textData[3].text = year;
        textData[4].text = temperature;
        textData[5].text = measure;
        
        listPlanets[idPlanet - 1].SetActive(true);
        listPlanets[idPlanet - 1].GetComponent<Animator>().SetTrigger("rotation");
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
