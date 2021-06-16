using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : MonoBehaviour
{
    public float CurrentSpeed;
    public float MaxForwardSpeed;
    public float MaxBackwardSpeed;
    public float Acceleration;
    public float Deceleration;
    
    public float TurnSpeed;
    public List<Weapon> Weapons;

    void Update()
    {

        
        if ((Input.GetKey(KeyCode.W)) && (CurrentSpeed < MaxForwardSpeed))
        {
            CurrentSpeed = CurrentSpeed + (Acceleration * Time.deltaTime);
        }
        else if ((Input.GetKey(KeyCode.S)) && (CurrentSpeed > -MaxBackwardSpeed))
        {
            CurrentSpeed = CurrentSpeed - (Acceleration * Time.deltaTime);
        }
        else
        {
            if (Math.Abs(CurrentSpeed) > Deceleration * Time.deltaTime)
                if (CurrentSpeed > 0)
                {
                    CurrentSpeed = CurrentSpeed - (Deceleration * Time.deltaTime);

                }
                else
                {
                    CurrentSpeed = CurrentSpeed + (Deceleration * Time.deltaTime);
                }
            else
            {
                CurrentSpeed = 0;
            }
        }

        transform.position -= transform.up * (CurrentSpeed * Time.deltaTime);

        

        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.forward * TurnSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            transform.Rotate(-Vector3.forward * TurnSpeed * Time.deltaTime);

    }
}
