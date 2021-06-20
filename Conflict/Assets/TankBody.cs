using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TankBody", menuName = "Tank/Create new Tank Body")]
public class TankBody : ScriptableObject
{ 
    public int DurabilityModifyer;
    public int NumberOfWeaponsModifyer;
    public float ForwardSpeedModifyer;
    public float BackwardsSpeedModifyer;
    public float AccelerationModifyer;
    public float DeccelerationModifyer;
    public float TurnModifyer;


    public void ApplyTankBodyData(PlayerTank tank)
    {
        tank.MaxForwardSpeed += ForwardSpeedModifyer;
        tank.MaxBackwardSpeed += BackwardsSpeedModifyer;
        tank.Acceleration += AccelerationModifyer;
        tank.Deceleration += AccelerationModifyer;
        tank.TurnSpeed += TurnModifyer;
    }
}
