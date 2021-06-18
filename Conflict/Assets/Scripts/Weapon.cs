using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/Create new Weapon Type")]
public class Weapon : ScriptableObject
{
    //This is a basic structure for the weapons
    public Sprite BulletSprite;
    public float Speed;
    public int Durability;
    public int Range;
    public bool Bouncy;
    public bool Homing;
    public int Damage;
}
