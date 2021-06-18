using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlefieldObject : MonoBehaviour
{

    public GameObject DestroyedObject;
    public GameObject PhysicsCollider;

    public int Health;
    public int DurabilityAbsorption;
    public bool Bouncy;

    // Start is called before the first frame update


    private void Start()
    {
        if (!Bouncy)
        {
            PhysicsCollider.layer = 9;
        }
    }

    void DestroyObject()
    {
        Instantiate(DestroyedObject, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public void TakeDamage(int Damage)
    {
        Health -= Damage;
        if(Health <= 0)
        {
            DestroyObject();
        }
    }
}
