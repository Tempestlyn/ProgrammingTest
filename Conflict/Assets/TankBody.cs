using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TankBody", menuName = "Tank/Create new Tank Body")]
public class TankBody : ScriptableObject
{

    public float DurabilityModifyer;
    public float SpeedModifyer;
    public float AccelerationModifyer;
    public float TurnModifyer;
    public int NumberOfWeaponsModifyer;
}
