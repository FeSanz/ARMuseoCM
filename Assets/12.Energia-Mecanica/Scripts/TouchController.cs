using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    [SerializeField] Animator notificacion;
    private bool firtsTouch = false;
    void Update()
    {

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "rotable")
                {
                    if (!firtsTouch)
                    {
                        firtsTouch = true;
                        StartCoroutine(animacion());
                    }
                    var objectScript = hit.collider.GetComponent<DragAndRotate>();
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
