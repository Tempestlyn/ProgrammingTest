using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Rigidbody2D rigidbody;
    public Weapon WeaponData;
    public float Speed;
    public float Range;
    public int Damage;
    public int Durability;
    private Collider2D collider;

    public GameObject ExplosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = gameObject.GetComponent<Collider2D>();


        Speed = WeaponData.Speed;
        Durability = WeaponData.Durability;
        Damage = WeaponData.Damage;
        rigidbody.AddForce(-transform.up * Speed);

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Object>())
        {
            Debug.Log("Test");
            ResolveHitObject(collider.gameObject.GetComponent<BattlefieldObject>());

        }
    }


    // Update is called once per frame
    void Update()
    {
        transform.up = -rigidbody.velocity;
    }

    public void ResolveHitObject(BattlefieldObject obj)
    {
        obj.TakeDamage(Damage);
        ReduceDurability(obj.DurabilityAbsorption);
    }

    public void ReduceDurability(int value)
    {
        Durability -= value;
        if (Durability <= 0)
        {
            DestroyBullet();
        }
    }
    public void DestroyBullet()
    {
        Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);

    }

}