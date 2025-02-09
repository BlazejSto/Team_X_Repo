using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coolness : MonoBehaviour
{
    float coolness;
    float decayrate;

    bool F;
    bool D;
    bool C;
    bool B;
    bool A;
    bool S;
    bool H;

    int GunMult;
    public List<float> GunMultList;
    float GunMultCounter;
    float GunMultMaxCount;

    bool ComboMult;
    float ComboMultVal;

    // Start is called before the first frame update
    void Start()
    {
        coolness = 0;
        decayrate = 1;

        GunMult = 0;
        GunMultMaxCount = 500;

        GunMultList = new List<float>();
        GunMultList.Add(1f);//default mult
        GunMultList.Add(2f);//shot 1
        GunMultList.Add(3f);//shot 2
        GunMultList.Add(5f);//shot 3
        GunMultList.Add(8f);
        GunMultList.Add(13f);
        GunMultList.Add(21f);//shot 6

        ComboMult = false;
        ComboMultVal = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        RankCheck();
    }

    private void FixedUpdate()
    {
        Decay();
        MultDecay();
    }


    public void CoolnessIncrese(float actionval)//called externally on an action or effect to increase coolness
    {
        float mult = MultCalc();
        coolness = coolness + (actionval * mult);

        if (coolness < -1000)// can't go below -1000
        {
            coolness = -1000;
        }

        if(coolness > 6000)// can't go above 6000
        {
            coolness = 6000;
        }
    }

    void RankCheck()//updates the player's rank based on their coolness
    {
        if(coolness < 0)//Less than 0 is rank F
        {
            F = true;
            D = false;
            C = false;
            B = false;
            A = false;
            S = false;
        }

        else if (coolness >= 0 && coolness < 1000)// 0 - 999 is D
        {
            F = false;
            D = true;
            C = false;
            B = false;
            A = false;
            S = false;
        }

        else if (coolness >= 1000 && coolness < 2000)// 1000 - 1999 is C
        {
            F = false;
            D = false;
            C = true;
            B = false;
            A = false;
            S = false;
        }

        else if(coolness >= 2000 && coolness < 3500)// 2000 - 3499 is B
        {
            F = false;
            D = false;
            C = false;
            B = true;
            A = false;
            S = false;
        }

        else if(coolness >= 3500 && coolness < 5000)// 3500 - 4999 is A
        {
            F = false;
            D = false;
            C = false;
            B = false;
            A = true;
            S = false;
        }

        else if(coolness >= 5000)// 5000 + is S
        {
            F = false;
            D = false;
            C = false;
            B = false;
            A = false;
            S = true;
        }
    }

    void Decay()//rate at which coolness decays, CANNOT go below rank D through decay, so D should be 0, and each rank should have a 'unique' decay (some may be shared) so have code to check which decay is run
    {
        coolness -= decayrate;
    }

    float MultCalc()//adds all multipliers together
    {
        float mult;

        mult = 0;

        mult += GunMultList[GunMult];

        if (ComboMult)
        {
            mult += ComboMultVal;
        }

        if (mult <= 0)
        {
            mult = 1;
        }

        return mult;
    }

    public void AddGunMult()
    {
        if (GunMult <= 6)
        {
            GunMult++;
            GunMultCounter = GunMultMaxCount;
        }
        else
        {
            GunMultCounter = GunMultMaxCount;
        }
    }

    void GunMultDecay()
    {
        if(GunMultCounter > 0)
        {
            GunMultCounter--;
        }
        else if (GunMult != 0)
        {
            GunMult = 0;
        }

    }

    void AddMult()//add a function for every unique multiplier
    {

    }

    void MultDecay()//add a function for every unique multiplier, this should ultimately be a coroutine that removes the multiplier after a certain amount of time (depending on the multiplier)
    {

    }

}
