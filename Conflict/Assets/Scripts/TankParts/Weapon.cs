using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/Create new Weapon Type")]
public class Weapon : ScriptableObject
{
    //This is a basic structure for the weapons
    public Sprite BulletSprite;
    public float Speed;
    public float RateOfFireModifyer;
    public int Durability;
    public ShotType shotType;
    public int Damage;
    public float HomingTurnSpeed;
    public string Name;
    [TextArea]
    public string Description;

}

public enum ShotType
{
    Standard,
    Bouncy,
    Homing
}


