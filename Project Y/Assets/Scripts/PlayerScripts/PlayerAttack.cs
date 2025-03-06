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

    GameObject LightBBat = default;//Light and Heavy Knife
    GameObject HeavyBBat = default;

    private bool lightAttacking = false;
    private bool heavyAttacking = false;

    private float timeToLightAttack = 0.25f;
    private float timeToHeavyAttack = 0.75f;
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

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            LightAttack();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            HeavyAttack();
        }

        if (lightAttacking)
        {
            timer += Time.deltaTime;

            if(timer >= timeToLightAttack)
            {
                timer = 0;
                lightAttacking = false;

                if (Melee == "Fists")
                {
                    LightAttackArea.SetActive(lightAttacking);
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
            }
        }

        if (heavyAttacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToHeavyAttack)
            {
                timer = 0;
                heavyAttacking = false;

                if (Melee == "Fists")
                {
                    HeavyAttackArea.SetActive(heavyAttacking);
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
            }
        }
    }

    private void HeavyAttack()
    {
        heavyAttacking = true;
        if (Melee == "Fists")
        {
            HeavyAttackArea.SetActive(heavyAttacking);
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
    }
    private void LightAttack()
    {
        lightAttacking = true;
        if (Melee == "Fists")
        {
            LightAttackArea.SetActive(lightAttacking);
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
    }
}
