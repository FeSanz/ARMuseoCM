using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllipseRender : MonoBehaviour
{
    [SerializeField, Tooltip("Numero de elementos en el arreglo")]
    public int pointsCount = 150;

    [SerializeField, Tooltip("Planeta a dibujar orbita")]
    public GameObject planet;

    [SerializeField, Tooltip("Detalle de orbita")]
    private int detailEllipse = 10;
    
    [SerializeField, Tooltip("Material de la orbita")]
    private Material materialEllipse;

    private int _index = 0;
    private int _indexFrame = -100;
    private LineRenderer _lineRenderer;
    
    void Start()
    {
        _lineRenderer = transform.gameObject.AddComponent<LineRenderer>();
        _lineRenderer.useWorldSpace = false;
        _lineRenderer.widthMultiplier = 0.05f;
        _lineRenderer.material = materialEllipse;
    }

    private void OnDisable()
    {
        _index = 0;
        _indexFrame = 0;
        _lineRenderer.positionCount = 0;
    }

    void Update()
    {
        //Dibujo linea de acuerdo a posición de planeta
        if (_index != pointsCount) 
        {
            if (detailEllipse == _indexFrame)
            {
                _lineRenderer.positionCount = _index + 1;
                _lineRenderer.SetPosition(_index, planet.transform.localPosition);
                
                _index++;
                _indexFrame = 0;
            }
            else
            {
                _indexFrame++;
            }
        }
    }
}
