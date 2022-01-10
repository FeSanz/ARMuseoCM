using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableIndicators : MonoBehaviour
{
    [SerializeField, Tooltip("Indicadores tipo fecha de secuencias de audio")] 
    private GameObject[] Arrows;

    public void HideArrows()
    {
        foreach (GameObject arrow in Arrows)
        {
           arrow.SetActive(false);
        }
    }
    
    public void ShowArrows()
    {
        foreach (GameObject arrow in Arrows)
        {
            arrow.SetActive(true);
        }
    }
}
