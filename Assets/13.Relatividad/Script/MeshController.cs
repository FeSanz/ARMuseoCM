using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Slider))]
public class MeshController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField, Tooltip("MeshSkin")]
    private SkinnedMeshRenderer skinnedMeshRendererGrid;

    [SerializeField, Tooltip("Planets")]
    private GameObject[] planets;
    public float[] diameters;

    [SerializeField, Tooltip("Scale Planet")]
    private float scaleB = 1.2f;
     
    private Slider slider;
    
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener( delegate {
            onValueChangeSlider();});

        for (int i=0; i<planets.Length; i++)
        {
            diameters[i] = planets[i].transform.localScale.x;
        }
    }

    /// <summary>
    ///     Function for bleding mesh 
    /// </summary>
    public void onValueChangeSlider() {
        skinnedMeshRendererGrid.SetBlendShapeWeight(0, slider.value * 120);

        for (int i=0; i<planets.Length; i++) {
            planets[i].transform.localScale = ( diameters[i] + (slider.value) * scaleB) * Vector3.one;
        }
    }
}
