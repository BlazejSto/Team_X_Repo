using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class ItemEffects : MonoBehaviour
{
    Rigidbody2D rigidBody;
    public float speed = 5.0f;
    //public float jumpForce = 8.0f;
    //public float airControlForce = 10.0f;
    //public float airControlMax = 1.5f;

    private float timer = 0f;
    
    public int HeavyAttackDamage = 10;
    int LightAttackDamage = 5;
    int RangedDamage;

    bool IsWeaponFists;
    bool IsWeaponKnuckles;
    bool IsWeaponKnife;
    bool IsWeaponBat;
    bool IsWeaponCrowbar;

    bool IsWeaponRevolver;
    bool IsWeaponColt;
    bool IsWeaponTommy;
    bool IsWeaponShotGun;
    bool IsWeaponFlamethrower;





    private bool IsFire;
    private bool IsIce;
    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        IsFire = false;
        IsIce = false;
    }
    // Update is called once per frame
    void Update()
    {
    }


    private void WhatWeapon()
    {
        if ((IsWeaponFists) || (IsWeaponKnuckles) || (IsWeaponKnife))
        {
            bool LightAttacker = true;
        }

        if ((IsWeaponBat) || (IsWeaponCrowbar))
        {
            bool HeavyAttacker = true;
        }

        if ((IsWeaponRevolver) || (IsWeaponColt) || (IsWeaponTommy) || (IsWeaponShotGun || (IsWeaponFlamethrower)))
        {
            bool RangeedAttacker = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bigger")
        {
            timer += Time.deltaTime;
            Destroy(coll.gameObject);
            if (timer < 10f)
            {
                rigidBody.transform.localScale = new Vector3(2, 2, 2);
            }
            timer = 0f;
        }

        if (coll.gameObject.tag == "Faster")
        {
            timer += Time.deltaTime;
            if (timer < 5f)
            {
                speed = 10.0f;
            }
            timer = 0f;
        }


        //Bullet is shot out twice from the player
        //This needs to last for a bit of time but not too much time (3 seconds?)
        //In the case of melee, it needs to register twice

        if (coll.gameObject.tag == "Double")
        {
            Destroy(coll.gameObject);
            
            timer += Time.deltaTime;
            if (timer < 4f)
            {
                
                //If statement here for if bullet or melee
                //If statement if heavy or light damage
                
                HeavyAttackDamage = HeavyAttackDamage * 2;
                Debug.Log(HeavyAttackDamage);
            }
            timer = 0f;
        }

        if(coll.gameObject.tag == "Piercing")
        {
            Destroy(coll.gameObject);
            timer += Time.deltaTime;
            if (timer < 3f)
            {
                //If statement here for if bullet or melee
                //If statement if heavy or light damage
                HeavyAttackDamage += HeavyAttackDamage * 4;
                Debug.Log(HeavyAttackDamage);

            }
            timer = 0f;

        }

        if (coll.gameObject.tag == "CoolMeterDependent")
        {
            Destroy(coll.gameObject);
            timer += Time.deltaTime;
            if (IsFire == true)
            {
                if(timer < 5f)
                {
                    //If statement here for if bullet or melee
                    //If statement if heavy or light damage
                    HeavyAttackDamage += HeavyAttackDamage * 5;
                    Debug.Log(HeavyAttackDamage);
                    //If coolness is bigger than 6100, turn this item effect off
                    //timer = 0f;
                    //coolness =+ value 
                }

                if (IsIce == true)
                {
                    //Get hypothermia value
                    //Add multiplier and apply to attacks
                    //HeavyAttackDamage = HeavyAttackDamage * //Multiplier from above;
                }
                timer = 0f;
            }
        }
  



    }
}


