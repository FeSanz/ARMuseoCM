using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MeshController : MonoBehaviour
{
    [SerializeField, Tooltip("MeshSkin")]
    private SkinnedMeshRenderer skinnedMeshRendererGrid;

    [SerializeField, Tooltip("Slider masa")] 
    private Slider slider;


    private float _zValue;
    void Start()
    {
        _zValue = transform.localPosition.z; //-13.5
    }

    /// <summary>
    /// Function for bleding mesh 
    /// </summary>
    public void onValueChangeSlider()
    {
        skinnedMeshRendererGrid.SetBlendShapeWeight(0, slider.value * 20);
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, _zValue - slider.value);
        //Planets.transform.localScale = Vector3.one * 1.2f;

    }
}
