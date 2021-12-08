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
    
    [SerializeField, Tooltip("Slider masa")] 
    private GameObject[] Planets;
    
    private float _zValue;

    private float[] _scales;
    void Start()
    {
        _scales = new float[9];
        for (int i = 0; i < 9; i++)
        {
            _scales[i] = Planets[i].transform.localScale.x - 0.05f;
            Planets[i].transform.localScale = new Vector3(_scales[i], _scales[i], _scales[i]);
        }
        _zValue = transform.localPosition.z; //-13.5
    }

    /// <summary>
    /// Function for bleding mesh 
    /// </summary>
    public void onValueChangeSlider()
    {
        skinnedMeshRendererGrid.SetBlendShapeWeight(0, slider.value * 20);
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, _zValue - slider.value);

        for (int i = 0; i < 9; i++)
        {
            float scale = _scales[i] + (slider.value / 100.0f);
            Planets[i].transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}
