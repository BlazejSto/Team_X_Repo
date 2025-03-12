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
    public float speed = 5.0f;
    //public float jumpForce = 8.0f;
    //public float airControlForce = 10.0f;
    //public float airControlMax = 1.5f;

    private float timer = 0f;

    public Coolness coolmeter;
    public ElementEffects effects;
    public PlayerAttack weapon;
    GameObject player;
    

    private bool IsLightAttacking = false;
    private bool IsHeavyAttacking = false;

    private bool IsMelee = false;
    private bool IsRanged = false;




    //private bool IsFire;
    //private bool IsIce;
    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        effects = GetComponent<ElementEffects>();

        coolmeter = player.GetComponent<Coolness>();

        weapon = GetComponent<PlayerAttack>();


        // if weapon.Melee == "Fists"
            //if weapon.
        //IsFire = false;
        //IsIce = false;
    }
    // Update is called once per frame
    void Update()
    {
    }


    
    private 
    
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


