using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
public class ItemEffects : MonoBehaviour
{

    // Current Progress as of 12/03/25
    // Improvements - Fire & Ice could be used (idk how tho :( ) 
    // Note - Item effects values for damage, speed and size can be altered if needed


    // Stuff that needs to go into Coolness script:
    //public float TimerMult = 0f; // Kit - Used for the duration of Item Effects. At the top of the script with the other variables
    //TimerMult = 1.5f; // Kit Addition - In Hypothermia 1
    //TimerMult = 2f; // Kit Addition - Hypothermia 3


    Rigidbody2D rigidBody; // Rigid Body
    public float speed = 5.0f; // Speed 

    private float timer = 0f; // Used to keep track of when an item was activated 

    public Coolness coolmeter; // Coolmeter values
    public ElementEffects effects; // Effects for Fire and Ice
    public PlayerAttack weapon; // Get Player weapon
    PlayerScript Speed; //gets player movement to change speed
    GameObject player; // Get Player


    public float ItemAttackMult = 1f;

    bool effectTimer = false;

    private float Mult = 0f; // This is used for the muliplier after fetching from coolness.TimerMult

    private bool IsLightAttacking = false; // Used for set damage/Multiplier
    private bool IsHeavyAttacking = false; // Used for set damage/Multiplier

    private bool IsMelee = false; // Check if it is a melee weapon
    private bool IsRanged = false; // Check if it is a ranged weapon


    // Use this for initialization
    void Start()
    {
        ItemAttackMult = 1f; //is 0 otherwise for god knows what reason

        player = Health.GetInstance().gameObject;//finds the player

        rigidBody = player.GetComponent<Rigidbody2D>(); // Get Rigid Body 

        effects = player.GetComponent<ElementEffects>(); // Fire and Ice

        //coolmeter = player.GetComponent<Coolness>(); // Coolmeter 

        weapon = player.GetComponent<PlayerAttack>(); //Getting weapon types

        Speed = player.GetComponent<PlayerScript>(); //for player speed

        Mult = 1f;
    }
    // Update is called once per frame

    private void WeaponTypeChecker()
    {
        // Check weapon is Melee
        if ((weapon.Melee == "Fists") || (weapon.Melee == "KDFists") || (weapon.Melee == "Knife") || (weapon.Melee == "BBAt") || (weapon.Melee == "Crowbar"))
        {
            IsMelee = true;
        }
        // Check Weapon is Ranged
        if ((weapon.Ranged == "Revolver") || (weapon.Ranged == "TGun") || (weapon.Ranged == "Colt") || (weapon.Ranged == "Shotgun") || (weapon.Ranged == "Flame"))
        {
            IsRanged = true;
        }
    }
    
    //private void WeaponMultiplierCheck ()
    //{
    //    if (IsMelee == true)
    //    {
    //        if (Input.GetKeyDown(KeyCode.J))
    //        {
    //            IsLightAttacking = true; // Checking if current attack is a light attack
    //        }

    //        if (Input.GetKeyDown(KeyCode.H))
    //        {
    //            IsHeavyAttacking = true; // Checking if current attack is a heavy attack
    //        }
    //    }

    //}

   // private void MultiplyingTime()
    //{
     //   if(coolmeter.TimerMult == 1.5f) // Getting the time Multiplier. This is for hypothermia 1
     //   {
      //      Mult = 1.5f;
      //  }

     //   if (coolmeter.TimerMult == 2f) // Hypothermia 3
      //  {
      //      Mult = 2f;
      //  }
   // }

    private void OnCollisionEnter2D(Collision2D coll) // Item Effects START
    {
        if (coll.gameObject.tag == "Bigger")
        {   
            if (timer < (10f * Mult)) // Start Item effect
            {
                effectTimer = true;
                rigidBody.transform.localScale = new Vector3(2, 4, 2); // Make sprite bigger
                Destroy(coll.gameObject);
            }
        }

        if (coll.gameObject.tag == "Faster")
        {
            if (timer < (10f * Mult)) // Start Item effect
            {
                effectTimer = true;
                speed = 10;
                Destroy(coll.gameObject);
            }
        }

        if (coll.gameObject.tag == "Double")
        {
            effectTimer = true;
            Destroy(coll.gameObject); // 
            if (timer < (10f * Mult)) // Start Item effect
            {
                ItemAttackMult = 2;

                //doubleE = true;
                ////if (IsRanged == true)
                ////{
                ////    ItemAttackMult = 1.5f; // Ranged damage increases 
                ////}

                //if (IsLightAttacking == true)
                //{
                //    ItemAttackMult = 1.25f; // Light damage increases 
                //}

                //if (IsHeavyAttacking == true)
                //{
                //    ItemAttackMult = 2f; // Heavy damage increases 
                //}

            }
        }

        //if (coll.gameObject.tag == "Piercing")
        //{
        //    Destroy(coll.gameObject);
        //    effectTimer = true;
        //    if (timer < (10f * Mult)) // Start Item effect
        //    {
        //        pierceE = true;
        //        if (IsRanged == true)
        //        {
        //            ItemAttackMult = 2.5f; // Ranged damage increases
        //        }

        //        //if (IsLightAttacking == true)
        //        //{
        //        //    ItemAttackMult = 2.25f; // Light damage increases
        //        //}

        //        //if (IsHeavyAttacking == true)
        //        //{
        //        //    ItemAttackMult = 3f; // Heavy damage increases
        //        //}

        //    }

        //}

    //    if (coll.gameObject.tag == "CoolMeterDependent")
    //    {
    //        Destroy(coll.gameObject);
    //        timer += Time.deltaTime;

    //        if (Mult == 1.5f) // Start Item effect ver 1
    //        {
    //            if (IsRanged == true)
    //            {
    //                ItemAttackMult = 1.55f; // Ranged damage increases
    //            }

    //            if (IsLightAttacking == true)
    //            {
    //                ItemAttackMult = 1.75f; // Light damage increases
    //            }

    //            if (IsHeavyAttacking == true)
    //            {
    //                ItemAttackMult = 2.25f; // Heavy damage increases
    //            }
    //        }

    //        if (Mult == 2f) // Start Item effect ver 2
    //        {
    //            if (IsRanged == true)
    //            {
    //                ItemAttackMult = 1.15f; // Ranged damage increases
    //            }

    //            if (IsLightAttacking == true)
    //            {
    //                ItemAttackMult = 1.25f; // Light damage increases
    //            }

    //            if (IsHeavyAttacking == true)
    //            {
    //                ItemAttackMult = 1.35f; // Heavy damage increases
    //            }

    //        }
    //            timer = 0f; // End timer
    //    }
    }


    void DefaultEffects()
    {
        rigidBody.transform.localScale = new Vector3(2, 2, 2);
        speed = 5;
        ItemAttackMult = 1f;

    }

    void Update()
    {
        if (effectTimer == true)
        {
            Effects();
        }

        IsLightAttacking = weapon.GetLight();
        IsHeavyAttacking = weapon.GetHeavy();

    }

    void FixedUpdate()
    {
        weapon.ItemDMG = ItemAttackMult; //this is probably gonna break badly but oh well
        Speed.speed = speed;
    }

    void Effects()
    {
        timer += Time.deltaTime; // Start the timer
        if(timer >= 10)
        {
            DefaultEffects();
            timer = 0f;
        }
    }


}


