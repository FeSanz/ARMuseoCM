using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class MeshController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField, Tooltip("MeshSkin")]
    private SkinnedMeshRenderer skinnedMeshRendererGrid1, skinnedMeshRendererGrid2,
        skinnedMeshRendererGrid3, skinnedMeshRendererGrid4;

    [SerializeField, Tooltip("Planets")]
    private GameObject planet1, planet2, planet3, planet4;

    [SerializeField, Tooltip("Scale Planet")]
    private float scaleB = 1.2f;

    private Slider slider;
    
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener( delegate {
            onValueChangeSlider();});
    }

    /// <summary>
    ///     Function for bleding mesh 
    /// </summary>
    public void onValueChangeSlider() {
        skinnedMeshRendererGrid1.SetBlendShapeWeight(0, slider.value * 120);
        skinnedMeshRendererGrid2.SetBlendShapeWeight(0, slider.value * 90);
        skinnedMeshRendererGrid3.SetBlendShapeWeight(0, slider.value * 60);
        skinnedMeshRendererGrid4.SetBlendShapeWeight(0, slider.value * 30);
        planet1.transform.localScale = (2f + (slider.value) * scaleB) * Vector3.one;
        planet2.transform.localScale = (1.5f + (slider.value) * scaleB) * Vector3.one;
        planet3.transform.localScale = (1f + (slider.value) * scaleB) * Vector3.one;
        planet4.transform.localScale = (0.5f + (slider.value) * scaleB) * Vector3.one;
    }
}
