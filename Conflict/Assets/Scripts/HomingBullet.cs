using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : Bullet
{
    /*
    public override void Start()
    {
        Debug.Log(HomingTurnSpeed);
        rigidbody = GetComponent<Rigidbody2D>();

        Damage = WeaponData.Damage;
        Speed = WeaponData.Speed;
        Durability = WeaponData.Durability;
    }
    */
    public override void Update()
    {
        if ((ControllingTank.IsPlayer1 && Input.GetKey(KeyCode.A)) || (!ControllingTank.IsPlayer1 && Input.GetKey(KeyCode.Keypad4)))
            transform.Rotate(Vector3.forward * WeaponData.HomingTurnSpeed * Time.deltaTime);

        if ((ControllingTank.IsPlayer1 && Input.GetKey(KeyCode.D)) || (!ControllingTank.IsPlayer1 && Input.GetKey(KeyCode.Keypad6)))
            transform.Rotate(-Vector3.forward * WeaponData.HomingTurnSpeed * Time.deltaTime);

        rigidbody.velocity = -transform.up * Speed;
        //transform.up = -rigidbody.velocity;
    }

}
