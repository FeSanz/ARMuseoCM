using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class MeshController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField, Tooltip("MeshSkin")]
    private SkinnedMeshRenderer skinnedMeshRendererGrid;

    [SerializeField, Tooltip("Planet")]
    private GameObject planet;

    [SerializeField, Tooltip("Scale Planet")]
    private float scaleB = 1.2f;

    private Slider slider;
    
    
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener( delegate {
            onValueChangeSlider();});
    }

    public void onValueChangeSlider() {
        skinnedMeshRendererGrid.SetBlendShapeWeight(0, slider.value * 100);
        planet.transform.localScale = (1.6f + (slider.value) * scaleB) * Vector3.one;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
