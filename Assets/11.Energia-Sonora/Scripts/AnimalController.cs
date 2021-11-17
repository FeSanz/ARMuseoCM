using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    [SerializeField] Animator notificacion;
    private bool firtsTouch = false;
    [SerializeField] GameObject snackbar;
    void Update()
    {
        if (AudioSettings.Mobile.muteState)
        {
            snackbar.SetActive(true);
        }
        else
        {
            snackbar.SetActive(false);
        }
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "animal")
                {
                    if (!firtsTouch)
                    {
                        firtsTouch = true;
                        StartCoroutine(animacion());
                    }
                    var objectScript = hit.collider.GetComponent<DragAndRotateAnimal>();
                    objectScript.isActive = !objectScript.isActive;
                }
            }
        }
    }

    IEnumerator animacion()
    {
        notificacion.Play("Out");
        yield return new WaitForSeconds(1);
        notificacion.gameObject.SetActive(false);
    }
}
