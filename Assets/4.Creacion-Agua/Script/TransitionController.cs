using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField, Tooltip("Boton para avanzar de Estado")]
    private Button nextButton;

    [SerializeField, Tooltip("Boton para regresar de Estado")]
    private Button backButton;

    [SerializeField, Tooltip("Incremento para Shader Transition")]
    private float increase = 0.005f;

    private Material materialEarth;
    private GameObject Asteroid;
    //Int assigned to state of Module
    public static int intState = 0;
   

    
    // Lava Shader Parameters
    private bool boolUpdateShader = false;
    private bool boolStateShader = false;
    public float floatShader = 1;

    // Pangea Shader Parameters
    private bool boolUpdateShaderPangea = false;
    private bool boolStateShaderPangea = false;
    public float floatShaderPangea = 0;

    // Earth Shader Parameters
    private bool boolUpdateShaderEarth = false;
    private bool boolStateShaderEarth = false;
    public float floatShaderEarth = 0;

    void Start()
    {
        materialEarth = GetComponent<Renderer>().material;
        Asteroid = transform.GetChild(0).gameObject;
    }


    public void advanceAnimState() {

        backButton.interactable = true;
        intState += 1;
        switch (intState) {
            //Initial Case Lava 
            case 0:
                break;
            // Lava Dry
            case 1:
                boolUpdateShader = true;
                boolStateShader = false;
                floatShader = materialEarth.GetFloat("FloatState");
                break;
            //Show Asteroid Up
            case 2:
                Asteroid.GetComponent<Animator>().Play("AsterioideAnim");
                break;
            //Collition Asteroid
            case 3:
                Asteroid.GetComponent<Animator>().Play("AsteroideCollision");
                break;
            //Enable Pangea Shader
            case 4:
                //Increase FloatPangea Shader
                boolUpdateShaderPangea = true;
                // boolStateShaderPangea true to Increase, false to Decrease
                boolStateShaderPangea = true;
                floatShaderPangea = materialEarth.GetFloat("FloatPangea");
                break;
            //Enable Earth Shader
            case 5:
                //Increase FloatEarth Shader
                boolUpdateShaderEarth = true;
                // boolStateShaderEarth true to Increase, false to Decrease
                boolStateShaderEarth = true;
                floatShaderEarth = materialEarth.GetFloat("FloatEarth");
                nextButton.interactable = false;
                break;
        }
    }

   


    public void backAnimState()
    {
        nextButton.interactable = true;
        intState = (intState - 1 % 2);
        switch (intState)
        {
            //Initial Case Lava 
            case 0:
                //Disable Button
                backButton.interactable = false;

                // Increase Shader
                boolUpdateShader = true;
                boolStateShader = true;
                floatShader = materialEarth.GetFloat("FloatState");
                break;
            //Second Case Lava Dry
            case 1:
                Asteroid.GetComponent<Animator>().Play("HiddenAsteroid");
                break;
            //Collition Asteroid
            case 2:
                Asteroid.GetComponent<Animator>().Play("AsterioideAnim");
                break;
            // Disable Pangea Shader
            case 3:
                //Decreace FloatPangea Shader
                boolUpdateShaderPangea = true;
                boolStateShaderPangea = false;
                floatShaderPangea = materialEarth.GetFloat("FloatPangea");
                break;
            // Disable Earth Shader
            case 4:
                //Decreace FloatPangea Shader
                boolUpdateShaderEarth = true;
                boolStateShaderEarth = false;
                floatShaderEarth = materialEarth.GetFloat("FloatEarth");
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Eneble Update Floar Value of Shader
        if (boolUpdateShader)
        {

            // Increase the Value 0 to 1
            if (boolStateShader)
            {
                floatShader += increase;
                materialEarth.SetFloat("FloatState", floatShader);
                if (floatShader >= 1) {
                    boolUpdateShader = false;
                }
            }
            // Decrease Value 1 to 0 
            else
            {
                floatShader -= increase;
                materialEarth.SetFloat("FloatState", floatShader);
                if (floatShader <= 0)
                {
                    boolUpdateShader = false;
                }
            }
        }

        //Eneble Update Floar Value of Shader Pangea
        if (boolUpdateShaderPangea)
        {

            // Increase the Value 0 to 1
            if (boolStateShaderPangea)
            {
                floatShaderPangea += increase;

                materialEarth.SetFloat("FloatPangea", floatShaderPangea);
                if (floatShaderPangea >= 1)
                {
                    boolUpdateShaderPangea = false;
                }
            }
            // Decrease Value 1 to 0 
            else
            {
                floatShaderPangea -= increase;
                materialEarth.SetFloat("FloatPangea", floatShaderPangea);
                if (floatShaderPangea <= 0)
                {
                    boolUpdateShaderPangea = false;
                }
            }
        }

        //Eneble Update Floar Value of Shader Earth
        if (boolUpdateShaderEarth)
        {

            // Increase the Value 0 to 1
            if (boolStateShaderEarth)
            {
                floatShaderEarth += increase;
                materialEarth.SetFloat("FloatEarth", floatShaderEarth);
                if (floatShaderEarth >= 1)
                {
                    boolUpdateShaderEarth = false;
                }
            }
            // Decrease Value 1 to 0 
            else
            {
                floatShaderEarth -= increase;
                materialEarth.SetFloat("FloatEarth", floatShaderEarth);
                if (floatShaderEarth <= 0)
                {
                    boolUpdateShaderEarth = false;
                }
            }
        }


    }


}
