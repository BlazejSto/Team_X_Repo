using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private GameObject LightAttackArea = default;
    private GameObject HeavyAttackArea = default;
    private bool lightAttacking = false;
    private bool heavyAttacking = false;

    private float timeToLightAttack = 0.25f;
    private float timeToHeavyAttack = 0.75f;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        LightAttackArea = transform.GetChild(0).gameObject;
        HeavyAttackArea = transform.GetChild(1).gameObject;
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
                LightAttackArea.SetActive(lightAttacking);
            }
        }

        if (heavyAttacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToHeavyAttack)
            {
                timer = 0;
                heavyAttacking = false;
                HeavyAttackArea.SetActive(heavyAttacking);
            }
        }
    }

    private void HeavyAttack()
    {
        heavyAttacking = true;
        HeavyAttackArea.SetActive(heavyAttacking);
    }
    private void LightAttack()
    {
        lightAttacking = true;
        LightAttackArea.SetActive(lightAttacking);
    }
}
