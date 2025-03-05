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

    float timer = 0f;
    
    int HeavyAttackDamage = 10;
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

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bigger")
        {
            Destroy(coll.gameObject);
            timer += Time.deltaTime;
            if (timer > 5f)
            {
                rigidBody.transform.localScale = new Vector3(2, 2, 2);
            }
        }

        if (coll.gameObject.tag == "Faster")
        {
            speed = 10.0f;
        }


        //Bullet is shot out twice from the player
        //This needs to last for a bit of time but not too much time (3 seconds?)
        //In the case of melee, it needs to register twice

        if (coll.gameObject.tag == "Double")
        {
            Destroy(coll.gameObject);
            timer += Time.deltaTime;
            if (timer > 3f)
            {
                HeavyAttackDamage = HeavyAttackDamage * 2;
                Debug.Log(HeavyAttackDamage);
            }  
        }

        if(coll.gameObject.tag == "Piercing")
        {

        }

        if(coll.gameObject.tag == "CoolMeterDependent")
        { 

        }



    }
}


