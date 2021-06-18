using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : MonoBehaviour
{
    //This script is meant to capture player functionality, including movement, shooting

    public float CurrentSpeed;
    public float MaxForwardSpeed;
    public float MaxBackwardSpeed;
    public float Acceleration;
    public float Deceleration;
    public float TurnSpeed;

    public int ActiveWeapon;
    public List<Weapon> Weapons;

    public GameObject BulletPrefab;
    public GameObject BouncyBulletPrefab;
    public GameObject HomingBulletPrefab;

    public Transform BulletSpawn;

    void Update()
    {

        //Player movement
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


        //This capture the player fire trigger, calls shoot
        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();
    }



    public void Shoot()
    {
        if (Weapons[ActiveWeapon].shotType == ShotType.Standard)
        {
            var bullet = Instantiate(BulletPrefab, BulletSpawn.position, BulletSpawn.transform.rotation).GetComponent<Bullet>();
            bullet.WeaponData = Weapons[ActiveWeapon];
            bullet.ControllingTank = this;
        }
        else if(Weapons[ActiveWeapon].shotType == ShotType.Bouncy)
        {
            var bullet = Instantiate(BouncyBulletPrefab, BulletSpawn.position, BulletSpawn.transform.rotation).GetComponent<Bullet>();
            bullet.WeaponData = Weapons[ActiveWeapon];
            bullet.ControllingTank = this;
        }
        else if(Weapons[ActiveWeapon].shotType == ShotType.Homing)
        {
            var bullet = Instantiate(HomingBulletPrefab, BulletSpawn.position, BulletSpawn.transform.rotation).GetComponent<Bullet>();
            bullet.WeaponData = Weapons[ActiveWeapon];
            bullet.ControllingTank = this;
        }
        else
        {
            Debug.LogError("No prefab exists for this shot type");
        }
        
    }
}
