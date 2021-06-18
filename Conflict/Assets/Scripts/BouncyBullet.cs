using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBullet : Bullet
{
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.GetComponent<Object>())
        {
            Debug.Log("Test");
            ResolveHitObject(collider.gameObject.GetComponent<BattlefieldObject>());

        }
    }
}
