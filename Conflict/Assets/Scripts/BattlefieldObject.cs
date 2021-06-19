using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlefieldObject : MonoBehaviour
{

    public DestroyedPrefab DestroyedObject;

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
        if (Random.value < (DestroyedObject.ChanceToSpawn / 100))
        {
            Instantiate(DestroyedObject.Prefab, transform.position, transform.rotation);
        }
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
[System.Serializable]
public struct DestroyedPrefab
{
    public GameObject Prefab;
    public float ChanceToSpawn;
}