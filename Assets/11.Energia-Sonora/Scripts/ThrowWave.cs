using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowWave : MonoBehaviour
{
    [SerializeField] GameObject Wave;
    // Start is called before the first frame update
    void Start()
    {

        //onda.GetComponent<Rigidbody>().AddForce(0, 0, 1, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject onda = Instantiate(Wave, transform.position - new Vector3(0, 0, 0), Quaternion.Euler(0,0,0));
        }
    }
}
