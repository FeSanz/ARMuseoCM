using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesBehaviour : MonoBehaviour
{
    [SerializeField, Tooltip("Vertices de referencia para dibujar linea")] private List<Transform> vertex = new List<Transform>();
    private LineRenderer line;


    void Start()
    {
        DrawLine();
    }
    public void DrawLine()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.useWorldSpace = false;
        line.startWidth = 0.5f;
        line.endWidth = 0.5f;
        line.widthMultiplier = 3.0f;
        //line.startColor = Color.red;
        //line.endColor = Color.red;
        line.positionCount = vertex.Count;

        for(int i = 0; i < vertex.Count; i++)
        {
            line.SetPosition(i, vertex[i].localPosition);
        }
    }

}
