using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private GameObject LightAttackArea = default;//Light and Heavy Fists
    private GameObject HeavyAttackArea = default;

    GameObject LightKDFists = default;//Light and Heavy Knuckle Dusters
    GameObject HeavyKDFists = default;

    GameObject LightKnife = default;//Light and Heavy Knife
    GameObject HeavyKnife = default;

    GameObject LightBBat = default;//Light and Heavy BaseballBat
    GameObject HeavyBBat = default;

    GameObject LightCrowbar = default;//Light and Heavy Crowbar
    GameObject HeavyCrowbar = default;

    private bool lightAttacking = false;
    private bool heavyAttacking = false;

    private float timeToLightAttack = 0.15f;
    private float LAcooldown = 0.3f;
    private float timeToHeavyAttack = 0.5f;
    private float HAcooldown = 1f;
    private float timer = 0f;

    public float DamageMult = 1f;

    public string Melee = "Fists"; //Change to one of the specified to change Weapons
    //List of Melee Weapons:
    //"Fists"
    //"KDFists"
    //"Knife"
    //"BBat"
    //"Crowbar"

    public string Ranged = "Revolver"; //Change to one of the specified to change Weapons
    //List of Ranged Weapons:
    //"Revolver"
    //"TGun"
    //"Colt"
    //"Shotgun"
    //"Flame"


    GameObject player;// player
    public Coolness coolness;//reference to Coolness


    // Start is called before the first frame update
    void Start()
    {
        LightAttackArea = transform.GetChild(0).gameObject; //Fist Hitboxes
        HeavyAttackArea = transform.GetChild(1).gameObject;

        LightKDFists = transform.GetChild(2).gameObject; //KnuckleDuster Hitboxes
        HeavyKDFists = transform.GetChild(3).gameObject;

        LightKnife = transform.GetChild(4).gameObject; //Knife Hitboxes
        HeavyKnife = transform.GetChild(5).gameObject;

        LightBBat = transform.GetChild(6).gameObject; //BaseballBat Hitboxes
        HeavyBBat = transform.GetChild(7).gameObject;

        LightCrowbar = transform.GetChild(8).gameObject; //Crowbar Hitboxes
        HeavyCrowbar = transform.GetChild(9).gameObject;

        player = Health.GetInstance().gameObject;//finds the player
        coolness = player.GetComponent<Coolness>();//gets the Coolness from the player

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J)&&!lightAttacking&&!heavyAttacking)
        {
            LightAttack();
        }

        if (Input.GetKeyDown(KeyCode.K) && !lightAttacking && !heavyAttacking)
        {
            HeavyAttack();
        }

        if (lightAttacking)
        {
            timer += Time.deltaTime;

            if(timer >= timeToLightAttack)
            {
                if (Melee == "Fists")
                {
                    LightAttackArea.SetActive(false);
                }
                else if (Melee == "KDFists")
                {
                    LightKDFists.SetActive(false);
                }
                else if (Melee == "Knife")
                {
                    LightKnife.SetActive(false);
                }
                else if (Melee == "BBat")
                {
                    LightBBat.SetActive(false);
                }
                else if (Melee == "Crowbar")
                {
                    LightCrowbar.SetActive(false);
                }
            }
            if(timer >= LAcooldown)
            {
                timer = 0;
                lightAttacking = false;
            }
        }

        if (heavyAttacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToHeavyAttack)
            {
                

                if (Melee == "Fists")
                {
                    HeavyAttackArea.SetActive(false);
                }
                if (Melee == "KDFists")
                {
                    HeavyKDFists.SetActive(false);
                }
                else if (Melee == "Knife")
                {
                    HeavyKnife.SetActive(false);
                }
                else if (Melee == "BBat")
                {
                    HeavyBBat.SetActive(false);
                }
                else if (Melee == "Crowbar")
                {
                    HeavyCrowbar.SetActive(false);
                }
            }
            if (timer >= HAcooldown)
            {
                timer = 0;
                heavyAttacking = false;
            }
        }
    }

    private void HeavyAttack()
    {
        heavyAttacking = true;
        if (Melee == "Fists")
        {
            HeavyAttackArea.SetActive(heavyAttacking);
            coolness.CoolnessIncrease(50);
        }
        if (Melee == "KDFists")
        {
            HeavyKDFists.SetActive(heavyAttacking);
        }
        else if (Melee == "Knife")
        {
            HeavyKnife.SetActive(heavyAttacking);
        }
        else if (Melee == "BBat")
        {
            HeavyBBat.SetActive(heavyAttacking);
        }
        else if (Melee == "Crowbar")
        {
            HeavyCrowbar.SetActive(heavyAttacking);
        }
    }
    private void LightAttack()
    {
        lightAttacking = true;
        if (Melee == "Fists")
        {
            LightAttackArea.SetActive(lightAttacking);
            coolness.CoolnessIncrease(500);
        }
        else if (Melee == "KDFists")
        {
            LightKDFists.SetActive(lightAttacking);
        }
        else if (Melee == "Knife")
        {
            LightKnife.SetActive(lightAttacking);
        }
        else if (Melee == "BBat")
        {
            LightBBat.SetActive(lightAttacking);
        }
        else if (Melee == "Crowbar")
        {
            LightCrowbar.SetActive(lightAttacking);
        }
    }
}
