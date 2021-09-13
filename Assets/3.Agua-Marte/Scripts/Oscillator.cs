using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Oscillator : MonoBehaviour
{
    public Transform rotationCenter;
    public float rotationRadius = 0.2f, angularSpeed = 1f;
    float posX = 0, posY = 0, posZ, angle = 0;

    // Update is called once per frame
    void Update()
    {
        posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
        //posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius;
        posZ = rotationCenter.position.z + Mathf.Sin(angle) * rotationRadius;

        transform.localPosition = new Vector3(posX, posY, posZ);
        angle = angle + Time.deltaTime * angularSpeed;
        if (angle >= 360f)
            angle = 0f;
    }
}
