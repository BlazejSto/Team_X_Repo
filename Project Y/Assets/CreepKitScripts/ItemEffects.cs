using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
public class ItemEffects : MonoBehaviour
{
    Rigidbody2D rigidBody;
    public float speed = 5.0f; // Speed 

    private float timer = 0f; // Used to keep track of when an item was activated 

    public Coolness coolmeter; // Coolmeter values
    public ElementEffects effects; // Effects for Fire and Ice
    public PlayerAttack weapon; // Get Player weapon
    GameObject player; // Get Player
    

    private bool IsLightAttacking = false; // Used for set damage/Multiplier
    private bool IsHeavyAttacking = false; // Used for set damage/Multiplier

    private bool IsMelee = false; // Check if it is a melee weapon
    private bool IsRanged = false; // Check if it is a ranged weapon

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>(); // Get Rigid Body 

        effects = GetComponent<ElementEffects>(); // Fire and Ice

        coolmeter = player.GetComponent<Coolness>(); // Coolmeter 

        weapon = GetComponent<PlayerAttack>(); //Getting weapon types

        //IsFire = false;
        //IsIce = false;
    }
    // Update is called once per frame
    void Update()
    {
    }


    private void WeaponTypeChecker()
    {
        if ((weapon.Melee == "Fists") || (weapon.Melee == "KDFists") || (weapon.Melee == "Knife") || (weapon.Melee == "BBAt") || (weapon.Melee == "Crowbar"))
        {
            IsMelee = true;
        }

        if ((weapon.Ranged == "Revolver") || (weapon.Ranged == "TGun") || (weapon.Ranged == "Colt") || (weapon.Ranged == "Shotgun") || (weapon.Ranged == "Flame"))
        {
            IsRanged = true;
        }
    }
    
    private void WeaponMultiplierCheck ()
    {
        if (IsMelee == true)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                IsLightAttacking = true;
            }

            if (Input.GetKeyDown(KeyCode.H))
            {
                IsHeavyAttacking = true;
            }
        }

        if (IsRanged == true)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                IsHeavyAttacking = true;
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bigger")
        {
            timer += Time.deltaTime; // Start the timer
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
                
                //HeavyAttackDamage = HeavyAttackDamage * 2;
                //Debug.Log(HeavyAttackDamage);
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
                //HeavyAttackDamage += HeavyAttackDamage * 4;
               // Debug.Log(HeavyAttackDamage);

            }
            timer = 0f;

        }

        if (coll.gameObject.tag == "CoolMeterDependent")
        {
            Destroy(coll.gameObject);
            timer += Time.deltaTime;
            //if (IsFire == true)
            {
                if(timer < 5f)
                {
                    //If statement here for if bullet or melee
                    //If statement if heavy or light damage
                    //HeavyAttackDamage += HeavyAttackDamage * 5;
                    //Debug.Log(HeavyAttackDamage);
                    //If coolness is bigger than 6100, turn this item effect off
                    //timer = 0f;
                    //coolness =+ value 
                }

                //if (IsIce == true)
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


