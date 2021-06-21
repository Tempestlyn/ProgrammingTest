using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : MonoBehaviour
{
    //This script is meant to capture player functionality, including movement, shooting
    
    public Player PlayerNumber;
    public bool IsPlayer1;

    public int Durability;

    public float CurrentSpeed;
    public float MaxForwardSpeed;
    public float MaxBackwardSpeed;
    public float Acceleration;
    public float Deceleration;
    public float TurnSpeed;

    public int NumberOfWeapons;
    public int ActiveWeapon;
    public List<Weapon> Weapons;
    public float FireRate;

    public LevelController levelController;

    public GameObject BulletPrefab;
    public GameObject BouncyBulletPrefab;
    public GameObject HomingBulletPrefab;

    public GameObject DestroyedPrefab;
    public GameObject ExplosionPrefab;
    public GameObject DestroyedParticles;

    public Transform BulletSpawn;

    private bool CanMove = true;
    private bool CanFire = true;
    private Rigidbody2D rigidbody;

    private void Start()
    {
        IsPlayer1 = PlayerNumber == Player.Player1;
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //Player movement
        if (CanMove)
        {
            if ((IsPlayer1 && (Input.GetKey(KeyCode.W)) && (CurrentSpeed < MaxForwardSpeed)) || (!IsPlayer1 && (Input.GetKey(KeyCode.Keypad8)) && (CurrentSpeed < MaxForwardSpeed)))
            {
                CurrentSpeed = CurrentSpeed + (Acceleration * Time.deltaTime);
            }
            else if ((IsPlayer1 && (Input.GetKey(KeyCode.S)) && (CurrentSpeed > -MaxBackwardSpeed)) || (!IsPlayer1 && (Input.GetKey(KeyCode.Keypad5)) && (CurrentSpeed > -MaxBackwardSpeed)))
            {
                CurrentSpeed = CurrentSpeed - (Acceleration * Time.deltaTime);
            }
            else
            {
                if (Math.Abs(CurrentSpeed) > Deceleration * Time.deltaTime)
                    if (CurrentSpeed > 0)
                    {
                        CurrentSpeed = CurrentSpeed - (Deceleration * Time.deltaTime);

                    }
                    else
                    {
                        CurrentSpeed = CurrentSpeed + (Deceleration * Time.deltaTime);
                    }
                else
                {
                    CurrentSpeed = 0;
                }
            }

            transform.position -= transform.up * (CurrentSpeed * Time.deltaTime);
            if (CurrentSpeed == 0)
            {
                rigidbody.velocity = new Vector2(0, 0);
            }

            if ((IsPlayer1 && Input.GetKey(KeyCode.A)) || (!IsPlayer1 && Input.GetKey(KeyCode.Keypad4)))
                transform.Rotate(Vector3.forward * TurnSpeed * Time.deltaTime);

            if ((IsPlayer1 && Input.GetKey(KeyCode.D)) || (!IsPlayer1 && Input.GetKey(KeyCode.Keypad6)))
                transform.Rotate(-Vector3.forward * TurnSpeed * Time.deltaTime);


            //This capture the player fire trigger, calls shoot
            if ((IsPlayer1 && Input.GetKeyDown(KeyCode.E)) || (!IsPlayer1 && Input.GetKeyDown(KeyCode.Keypad9)))
            {
                if (CanFire)
                {
                    
                    StartCoroutine("Shoot");
                }
            }

            if ((IsPlayer1 && Input.GetKeyDown(KeyCode.Q)) || (!IsPlayer1 && Input.GetKeyDown(KeyCode.Keypad7)))
            {
                NextWeapon();
            }

        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.GetComponent<BattlefieldObject>())
        {
            var battleObject = collider.gameObject.GetComponent<BattlefieldObject>();
            if (battleObject.Durability + 1 < Durability)
            {
                battleObject.ReduceDurability(Durability);
            }
        }
    }

    public IEnumerator Shoot()
    {
        CanFire = false;
        if (Weapons[ActiveWeapon].shotType == ShotType.Standard)
        {
            var bullet = Instantiate(BulletPrefab, BulletSpawn.position, BulletSpawn.transform.rotation).GetComponent<Bullet>();
            bullet.WeaponData = Weapons[ActiveWeapon];
            bullet.ControllingTank = this;
        }
        else if(Weapons[ActiveWeapon].shotType == ShotType.Bouncy)
        {
            var bullet = Instantiate(BouncyBulletPrefab, BulletSpawn.position, BulletSpawn.transform.rotation).GetComponent<Bullet>();
            bullet.WeaponData = Weapons[ActiveWeapon];
            bullet.ControllingTank = this;
        }
        else if(Weapons[ActiveWeapon].shotType == ShotType.Homing)
        {
            var bullet = Instantiate(HomingBulletPrefab, BulletSpawn.position, BulletSpawn.transform.rotation).GetComponent<Bullet>();
            bullet.WeaponData = Weapons[ActiveWeapon];
            bullet.ControllingTank = this;
        }
        else
        {
            Debug.LogError("No prefab exists for this shot type");
        }
        yield return new WaitForSeconds(FireRate + Weapons[ActiveWeapon].RateOfFireModifyer);
        CanFire = true;
        
    }


    public int ReduceDurability(int Damage)
    {
        Durability -= Damage;
        if (Durability <= 0)
        {
            DestroyTank();
        }
        return Durability;
    }

    public void DestroyTank()
    {
        CanMove = false;
        GetComponent<SpriteRenderer>().sprite = null;
        var explosionPrefab = Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        explosionPrefab.GetComponent<Animator>().SetInteger("ExplosionType", 2);
        Instantiate(DestroyedPrefab, transform);
        var particles = Instantiate(DestroyedParticles, transform.position, DestroyedParticles.transform.rotation);
        particles.GetComponent<ParticleSystem>().Play();
        rigidbody.velocity = new Vector2(0, 0);
        rigidbody.isKinematic = true;
        if (!levelController.RoundEnded)
        {
            StartCoroutine("EndRound");
        }
    }

    IEnumerator EndRound()
    {
        levelController.RoundEnded = true;
        if(IsPlayer1)
        {
            levelController.IncreasePlayerScore(Player.Player2);
        }
        else
        {
            levelController.IncreasePlayerScore(Player.Player1);
        }
        yield return new WaitForSeconds(3);
        levelController.Refresh();
    }

    public void NextWeapon()
    {
        ActiveWeapon += 1;
        if(ActiveWeapon >= Weapons.Count)
        {
            ActiveWeapon = 0;
        }
        if (IsPlayer1)
        {
            levelController.Player1ActiveWeaponText.text = Weapons[ActiveWeapon].Name;
        }
        else
        {
            levelController.Player2ActiveWeaponText.text = Weapons[ActiveWeapon].Name;
        }
    }
}

public enum Player
{
    Player1,
    Player2
}

public enum PlayerColor
{
    Blue,
    Red
}