using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllipseRender : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private List<Vector3> listPoints;
    
    [SerializeField, Tooltip("Numero de elementos en el arreglo")]
    public int pointsCount = 150;

    [SerializeField, Tooltip("PlanetToFollow")]
    public GameObject planet;

    [SerializeField]
    private int detailEllipse = 10;
    
    [SerializeField]
    private Material materialEllipse;

    private int index = 0;
    private int indexFrame = -100;
    
    void Start()
    {

        lineRenderer = transform.gameObject.AddComponent<LineRenderer>();
        lineRenderer.useWorldSpace = false;
        lineRenderer.widthMultiplier = 0.05f;
        lineRenderer.material = materialEllipse;



    }

    private void OnDisable()
    {
        index = 0;
        indexFrame = 0;
        lineRenderer.positionCount = 0;
    }

    void Update()
    {
        if (index != pointsCount) 
        {

            if (detailEllipse == indexFrame)
            {
                lineRenderer.positionCount = index+1;
                lineRenderer.SetPosition(index, planet.transform.localPosition);
                Debug.Log(index);
                
                index++;
                indexFrame = 0;
            }

            else
            {
                indexFrame++;
            }
        }


    }
}
