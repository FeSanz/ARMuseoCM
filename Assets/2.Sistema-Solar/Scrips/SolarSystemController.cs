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
    
    [SerializeField, Tooltip("Sistema de particulas del sol")]
    private ParticleSystem particleSun;

    [SerializeField, Tooltip("Lista de planetas a mostrar individualmente")]
    private GameObject[] listPlanets;
    
    [SerializeField, Tooltip("Titulo, Descripcion, D�as, A�os, Temperatura, Medidas")]
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
                    "Es el planeta m�s peque�o de nuestro sistema solar, tiene una atm�sfera poco densa.",
                    "* Su d�a dura 59 d�as terrestres", "* Su a�o dura 88 d�as terrestres",
                    "* M�xima 427 �C \n* M�nima -173 �C","* Di�metro de \n4,879.4 km"
                    );
                break;
            case 2:
                PlanetSelectedData( idPlanetSelected, "VENUS", 
                    "Su atmosfera est� compuesta por di�xido de carbono, fue nombrada en honor a la diosa romana del amor",
                    "* Su d�a dura 243 d�as terrestres", "* Su a�o dura 225 d�as terrestres",
                    "* M�xima 499.85 �C \n? M�nima -45.15  �C","* Di�metro de \n12,104 km"
                );
                break;
            case 3:
                PlanetSelectedData( idPlanetSelected, "TIERRA", 
                    "Nuestro hogar, su atmosfera est� compuesta mayormente de nitr�geno y ox�geno, superficie cubierta por 75% de agua",
                    "* Su d�a dura 24 horas", "* Su a�o dura 365.25 d�as",
                    "* M�xima 56.7 �C \n* M�nima -89.15 �C","* Di�metro de \n12.756 km"
                );
                break;
            case 4:
                PlanetSelectedData( idPlanetSelected, "MARTE", 
                    "Conocido como el planeta rojo, su atmosfera est� compuesta mayormente de di�xido de carbono",
                    "* Su d�a dura 24.6 horas", "* Su a�o dura 687 d�as terrestres",
                    "* M�xima 20 �C \n* M�nima -140 �C","* Di�metro de \n6,779 km"
                );
                break;
            case 5:
                PlanetSelectedData( idPlanetSelected, "J�PITER", 
                    "Planeta en estado gaseoso, es 1,300 veces m�s grande que la Tierra y es el m�s grande del sistema solar, 79 lunas confirmadas.",
                    "* Su d�a dura 10 horas", "* Su a�o dura 11.8 a�os terrestres",
                    "* M�xima 121 �C \n* M�nima -163 �C","* Di�metro de \n139,820 km"
                );
                break;
            case 6:
                PlanetSelectedData( idPlanetSelected, "SATURNO", 
                    "Segundo planeta m�s grande del sistema, es un planeta gaseoso, tiene anillos hechos de pedazos de hielo y roca.",
                    "* Su d�a dura 10.7 horas", "* Su a�o dura 29 a�os terrestres",
                    "* M�xima -130.15 �C \n* M�nima -191.15 �C","* Di�metro de \n116,460 km"
                );
                break;
            case 7:
                PlanetSelectedData( idPlanetSelected, "URANO", 
                    "Compuesto de agua, metano y amoniaco, tiene anillos tenues, su atm�sfera est� hecha de hidr�geno y helio.",
                    "* Su d�a dura 17 horas y 14 minutos", "* Su a�o dura 84 a�os terrestres",
                    "* Media -205 �C \n* M�nima -214.2 �C","* Di�metro de \n50,724 km"
                );
                break;
            case 8:
                PlanetSelectedData( idPlanetSelected, "NEPTUNO", 
                    "Su nombre es debido al dios griego de los mares Neptuno, su atm�sfera se compone de hidr�geno, helio y metano, es oscuro, fr�o y muy ventoso.",
                    "* Su d�a dura 16 horas", "* Su a�o dura 164 a�os terrestres",
                    "* M�xima -217.15 �C \n* Media -220 �C","* Di�metro de \n49,244 km"
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
