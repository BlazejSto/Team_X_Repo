using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour
{
    public Coolness cool;

    float fire1;
    float fire2;
    float fire3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(fire1) > 0.0f)
        {
            LightAttack();
        }

        if (Mathf.Abs(fire2) > 0.0f)
        {
            HeavyAttack();
        }

        if (Mathf.Abs(fire3) > 0.0f)
        {
            Gun();
        }
    }

    void Inputs()
    {
        fire1 = Input.GetAxis("Fire1");
        fire2 = Input.GetAxis("Fire2");
        fire3 = Input.GetAxis("Fire3");
    }

    void LightAttack()
    {
        cool.CoolnessIncrease(10);
        
    }

    void HeavyAttack()
    {
        cool.CoolnessIncrease(25);
    }

    void Gun()
    {
        cool.CoolnessIncrease(30);
    }

    void ComboTracker()
    {

    }
}
