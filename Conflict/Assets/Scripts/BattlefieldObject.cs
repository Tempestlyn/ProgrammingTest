using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlefieldObject : MonoBehaviour
{

    public GameObject DestroyedObject;

    public int Durability;
    public bool Bouncy;

    // Start is called before the first frame update


    private void Start()
    {
        if (Bouncy)
        {
            GetComponent<Collider2D>().isTrigger = false;
        }
        else
        {
            GetComponent<Collider2D>().isTrigger = true;
        }
    }

    void DestroyObject()
    {
        Instantiate(DestroyedObject, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public int ReduceDurability(int Damage)
    {
        Durability -= Damage;
        if(Durability <= 0)
        {
            DestroyObject();
        }
        return Durability;
    }
}
