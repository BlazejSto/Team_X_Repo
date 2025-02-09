using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour
{
    public Coolness cool;

    float fire1;
    float fire2;
    float fire3;

    
    bool Light;
    float LiDecCounter;

    bool Heavy;
    float HeDecCounter;

    float basicCountMax;

    // Start is called before the first frame update
    void Start()
    {
        Combo = false;
        Light = false;
        Heavy = false;

        
        LiDecCounter = 0;
        HeDecCounter = 0;

        basicCountMax = 50;
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();

        HeavyDecay();
        LightDecay();

        ComboTracker();
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

        if(!Light)
        {
            Light = true;
            LiDecCounter = basicCountMax;
        }
        else
        {
            LiDecCounter = basicCountMax;
        }

    }

    void LightDecay()
    {
        if (LiDecCounter > 0)
        {
            LiDecCounter--;
        }
        else if (LiDecCounter == 0)
        {
            Light = false;
        }
    }

    void HeavyAttack()
    {
        cool.CoolnessIncrease(25);
        
        if (!Heavy)
        {
            Heavy = true;
            HEDecCounter = basicCountMax;
        }
        else
        {
            HeDecCounter = basicCountMax;
        }
    }

    void HeavyDecay()
    {
        if (HeDecCounter > 0)
        {
            HeDecCounter--;
        }
        else if (HeDecCounter == 0)
        {
            Heavy = false;
        }
    }

    void Gun()
    {
        cool.CoolnessIncrease(30);
        cool.AddGunMult();
    }

    void ComboTracker()
    {
        if(Heavy && Light)
        {
            cool.AddComboMult();
        }
    }

}
