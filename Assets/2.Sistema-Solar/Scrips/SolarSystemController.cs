using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;


public class SolarSystemController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField, Tooltip("Animator Solar System")]
    private Animator animatorSolarSystem;

    [SerializeField, Tooltip("Lista de los Planetas en PivotPlanets")]
    private GameObject[] listPlanets;

    Dictionary<string, string> diccionario = new Dictionary<string, string>();
    [SerializeField, Tooltip("Text Titel")]
    private TextMeshProUGUI textTitle;

    [SerializeField, Tooltip("Text Body")]
    private TextMeshProUGUI textBody;

    void Start()
    {
        diccionario.Add("Sistema Solar", "El movimiento de los planetas es descrito en forma eliptica alrededor del Sol");
        diccionario.Add("Mercurio", "Es el planeta mas pequeño, tarda 88 dias en dar la vuelta al sol");
        diccionario.Add("Venus", "Su atmosfera esta compuesta por Dioxido de Carbono /n " +
            "Fue nombrada asi en Honor a la Diosa Romana del amor");
        diccionario.Add("Tierra", "Su atmosfera es esta compuesta mayormente de Nitrogeno y Oxigeno \n La superficie esta cubierta por 75% de Agua");
        diccionario.Add("Marte", "Es conocido como el planeta rojo \n Su atmosfera ep-sta compuesta casi en sus totalidad de Dioxido de Carbono");
        diccionario.Add("Jupiter", "Es un planeta en estado gaseoso, es el planeta mas grande del sistema solar \n Es 1300 veces mas grande que la Tierra ");
        diccionario.Add("Saturno", "Es el segundo planeta mas grande del sistema, es un planeta gaseoso, tiene un anillo a su alredor");
        diccionario.Add("Urano", "Tiene una inclinacion de 90 grados respecto al plano solar, su temperatura es de -200° C ");
        diccionario.Add("Neptuno", "Su nombre es debido al dios Griego de los mares, es el ultimo planeta del sistema y tarda  164 años en dar la vuelta al Sol  ");
        textTitle.text = diccionario.Keys.ElementAt(0);
        textBody.text = diccionario.Values.ElementAt(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activePlanets(int idButton) {
        switch (idButton) {
            case 0:
                hideAllPlanets();
                showSolarSystem();
                textTitle.text = diccionario.Keys.ElementAt(0);
                textBody.text = diccionario.Values.ElementAt(0);
                break;

            default: 
                animatorSolarSystem.Play("AnimSolarSystemHide");
                textTitle.text = diccionario.Keys.ElementAt(idButton);
                textBody.text = diccionario.Values.ElementAt(idButton);
                hideAllPlanets();
                listPlanets[idButton-1].SetActive(true);
                listPlanets[idButton - 1].GetComponent<Animator>().SetTrigger("rotation");
                break;
        }

    }

    public void hideAllPlanets()
    {
        foreach(GameObject planet in listPlanets) {
            planet.SetActive(false);
            
        }
    }

    public void hideSolarSystem() {
        animatorSolarSystem.gameObject.SetActive(false);
    }
    public void showSolarSystem()
    {
        animatorSolarSystem.gameObject.SetActive(true);
    }
}
