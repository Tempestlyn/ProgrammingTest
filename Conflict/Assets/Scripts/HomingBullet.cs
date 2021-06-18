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
        transform.rotation = ControllingTank.transform.rotation;
        rigidbody.velocity = -transform.up * Speed;
        //transform.up = -rigidbody.velocity;
    }

}
