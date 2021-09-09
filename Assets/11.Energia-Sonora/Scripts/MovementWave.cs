using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementWave : MonoBehaviour
{
    // Start is called before the first frame update
    public int velocidad = 2;
    float timer = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        int seconds = (int)timer;
        //transform.localScale = new Vector3(Time.deltaTime * velocidad, Time.deltaTime * velocidad, Time.deltaTime * velocidad);
        gameObject.transform.localScale += new Vector3(1.5f, 1.5f, 1.5f);
        if (seconds == 3)
        {
            destroy();
        }
        //transform.Translate(Vector3.forward * Time.deltaTime * velocidad);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void destroy()
    {
        Destroy(gameObject);
    }
}
