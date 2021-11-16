using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitPaint : MonoBehaviour
{
    [SerializeField, Tooltip("Planeta a orbitar")]
    private GameObject Ellipeseplanet;
    
    [SerializeField, Tooltip("Tamaño de orbita")]
    private float radius;
    
    [SerializeField, Tooltip("Velocidad de traslacion")]
    private float speed;
    
    [SerializeField, Tooltip("Material de la orbita")]
    private Material materialEllipse;

    private LineRenderer _lineRenderer;
    private float _time = 0;
    
    void Start()
    {
        var segments = 360;
       _lineRenderer = Ellipeseplanet.transform.gameObject.AddComponent<LineRenderer>();
       _lineRenderer.useWorldSpace = false;
       _lineRenderer.widthMultiplier = 0.05f;
       _lineRenderer.material = materialEllipse;
       _lineRenderer.positionCount = segments + 1;

       // agregue un punto extra para hacer que el punto de inicio y el punto final sean iguales para cerrar el círculo
       var pointCount = segments + 1;
       var points = new Vector3[pointCount];

       for (int i = 0; i < pointCount; i++)
       {
           var rad = Mathf.Deg2Rad * (i * 360f / segments);
           points[i] = new Vector3(Mathf.Sin(rad) * radius, 0, Mathf.Cos(rad) * radius);
       }

       _lineRenderer.SetPositions(points);
    }

    private void Update()
    {
        _time += Time.deltaTime * speed;
        transform.localPosition = new Vector3(Mathf.Cos(_time) * radius, 0, Mathf.Sin(_time) * radius);
    }
}
