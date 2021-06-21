using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TankHull", menuName = "Tank/Create new Tank Hull")]
public class TankHull : ScriptableObject
{
    //Holds the data for hull object. In hindsight should have used polymorphism. 
    public int DurabilityModifyer;
    public int NumberOfWeapons;
    public float ForwardSpeedModifyer;
    public float BackwardsSpeedModifyer;
    public float AccelerationModifyer;
    public float DeccelerationModifyer;
    public float TurnModifyer;
    public float ScaleModifyer;
    public string Name;
    [TextArea]
    public string Description;

    public void ApplyTankBodyData(PlayerTank tank)
    {
        tank.Durability += DurabilityModifyer;
        tank.MaxForwardSpeed += ForwardSpeedModifyer;
        tank.MaxBackwardSpeed += BackwardsSpeedModifyer;
        tank.Acceleration += AccelerationModifyer;
        tank.Deceleration += AccelerationModifyer;
        tank.TurnSpeed += TurnModifyer;
        tank.transform.localScale = tank.transform.localScale *= ScaleModifyer;
    }
}
