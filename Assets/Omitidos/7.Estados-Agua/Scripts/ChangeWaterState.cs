using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWaterState : MonoBehaviour
{
    [SerializeField] GameObject Solido;
    [SerializeField] GameObject Liquido;
    [SerializeField] GameObject Gaseoso;
    [SerializeField] GameObject Contorno;

    public void ChangeToSolido()
    {
        DisableAll();
        Solido.SetActive(true);
        Contorno.transform.localPosition = new Vector2(-175.3f, 0);
    }
    public void ChangeToLiquido()
    {
        DisableAll();
        Liquido.SetActive(true);
        Contorno.transform.localPosition = new Vector2(0, 0);
    }
    public void ChangeToGaseoso()
    {
        DisableAll();
        Gaseoso.SetActive(true);
        Contorno.transform.localPosition = new Vector2(175.3f, 0);
    }
    private void DisableAll()
    {
        Solido.SetActive(false);
        Liquido.SetActive(false);
        Gaseoso.SetActive(false);
    }
}
