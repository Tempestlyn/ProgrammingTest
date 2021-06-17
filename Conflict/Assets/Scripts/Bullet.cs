using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Rigidbody2D rigidbody;
    public Weapon WeaponData;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        Speed = WeaponData.Speed; 

        rigidbody.AddForce(-transform.up * Speed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.up = -rigidbody.velocity;

    }
}
