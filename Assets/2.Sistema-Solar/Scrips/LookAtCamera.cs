using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    void LateUpdate()
    {
        transform.LookAt(Camera.main.transform,transform.up);
        //transform.rotation = Camera.main.transform.rotation;
    }
}
