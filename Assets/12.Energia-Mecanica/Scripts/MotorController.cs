using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorController : MonoBehaviour
{
    [SerializeField] Animator motor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AplicarTransparencia()
    {

    }

    public void PauseAnimation()
    {
        motor.speed = 0;
    }
    public void PlayAnimation()
    {
        motor.speed = 1;
    }
}
