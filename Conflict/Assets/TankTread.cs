using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TankTread", menuName = "Tank/Create new Tank Tread")]
public class TankTread : ScriptableObject
{
    public float ForwardSpeedModifyer;
    public float BackwardsSpeedModifyer;
    public float AccelerationModifyer;
    public float DeccelerationModifyer;
    public float TurnModifyer;
    public int DurabilityModifyer;

    public string Name;
    [TextArea]
    public string Description;

    public void ApplyTankBodyData(PlayerTank tank)
    {
        tank.MaxForwardSpeed += ForwardSpeedModifyer;
        tank.MaxBackwardSpeed += BackwardsSpeedModifyer;
        tank.Acceleration += AccelerationModifyer;
        tank.Deceleration += AccelerationModifyer;
        tank.TurnSpeed += TurnModifyer;
        tank.Durability += DurabilityModifyer;
    }
}
