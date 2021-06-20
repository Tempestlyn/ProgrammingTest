using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Rigidbody2D rigidbody;
    public Weapon WeaponData;
    public float Speed;
    public float Range;
    public int Durability;
    public int Damage;
    public float HomingTurnSpeed;

    public GameObject ExplosionPrefab;
    public PlayerTank ControllingTank;

    // Start is called before the first frame update
    public virtual void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        Damage = WeaponData.Damage;
        Speed = WeaponData.Speed;
        Durability = WeaponData.Durability;
        HomingTurnSpeed = WeaponData.HomingTurnSpeed;
        rigidbody.velocity = -transform.up * Speed;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.GetComponent<BattlefieldObject>())
        {
            ResolveHitObject(collider.gameObject.GetComponent<BattlefieldObject>());
        }
    }


    public virtual void Update()
    {
        transform.up = -rigidbody.velocity;
    }

    public virtual void ResolveHitObject(BattlefieldObject obj)
    {
        var objDurability = obj.Durability;
        if (obj.ReduceDurability(Damage) > 0)
        {
            DestroyBullet();
        }      
        ReduceDurability(objDurability);
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
