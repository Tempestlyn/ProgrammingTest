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
    public int Durability;
    public int Range;
    [HideInInspector]
    public ShotType shotType;
    public int Damage;
    [HideInInspector]
    public float HomingTurnSpeed;
}

public enum ShotType
{
    Standard,
    Bouncy,
    Homing
}

[CustomEditor(typeof(Weapon))]
public class MyScriptEditor : Editor
{
    Weapon weapon;
    string[] originalFields = new string[] { "myStringA", "m_script" };
    private void OnEnable()
    {
        weapon = (Weapon)target;
    }
    public override void OnInspectorGUI()
    {
        DrawPropertiesExcluding(serializedObject, originalFields);
        weapon.shotType = (ShotType)EditorGUILayout.EnumPopup("ShotType", weapon.shotType);
        
        switch (weapon.shotType)
        {
            case ShotType.Homing:
            {
                    weapon.HomingTurnSpeed = EditorGUILayout.FloatField("Homing Turn Speed", weapon.HomingTurnSpeed);
                    break;
            }
        }

        serializedObject.ApplyModifiedProperties();
    }
}
