using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBullet : Bullet
{
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.GetComponent<BattlefieldObject>())
        {
            ResolveHitObject(collider.gameObject.GetComponent<BattlefieldObject>());
        }
    }

    public override void ResolveHitObject(BattlefieldObject obj)
    {
        var objDurability = obj.Durability;

        if (obj.Bouncy)
        {
            obj.ReduceDurability(Damage);
            ReduceDurability(1);
        }
        //If the colliding object can't be bounced off of, then this bullet behaves like a normal bullet
        else
        {
            if (obj.ReduceDurability(Damage) > 0)
            {
                DestroyBullet();
            }
            ReduceDurability(objDurability);
        }
    }
}
