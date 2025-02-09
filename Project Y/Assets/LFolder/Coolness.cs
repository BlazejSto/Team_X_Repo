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

    char Rank;

    int GunMult;
    public List<float> GunMultList;
    float GunMultCounter;
    float GunMultMaxCount;

    float GenericMaxCounter;

    bool ComboMult;
    float ComboMultVal;
    float ComboMultCounter;

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

        GenericMaxCounter = 250;

        ComboMult = false;
        ComboMultVal = 1.5f;
        ComboMultCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        RankCheck();

        GunMultDecay();
        ComboMultDecay();

        Debug.Log("Rank"+Rank);
        Debug.Log("GunMult"+GunMult);
        Debug.Log("ComboMult"+ComboMult);
    }

    private void FixedUpdate()
    {
        Decay();

        //MultDecay();
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
        Debug.Log("New Coolness = "+coolness);
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

            Rank = 'f';
        }

        else if (coolness >= 0 && coolness < 1000)// 0 - 999 is D
        {
            F = false;
            D = true;
            C = false;
            B = false;
            A = false;
            S = false;

            Rank = 'd';
        }

        else if (coolness >= 1000 && coolness < 2000)// 1000 - 1999 is C
        {
            F = false;
            D = false;
            C = true;
            B = false;
            A = false;
            S = false;

            Rank = 'c';
        }

        else if(coolness >= 2000 && coolness < 3500)// 2000 - 3499 is B
        {
            F = false;
            D = false;
            C = false;
            B = true;
            A = false;
            S = false;

            Rank = 'b';
        }

        else if(coolness >= 3500 && coolness < 5000)// 3500 - 4999 is A
        {
            F = false;
            D = false;
            C = false;
            B = false;
            A = true;
            S = false;

            Rank = 'a';
        }

        else if(coolness >= 5000)// 5000 + is S
        {
            F = false;
            D = false;
            C = false;
            B = false;
            A = false;
            S = true;

            Rank = 's';
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

        mult += GunMultList[GunMult];//adds the gun mult from the list

        if (ComboMult)// if ComboMult is true it adds to the multiplier
        {
            mult += ComboMultVal;
        }

        if (mult <= 0)// if the multiplier is 0 after everything then it becomes 1 // THIS ALWAYS GOES LAST
        {
            mult = 1;
        }

        return mult;
    }

    public void AddGunMult()//calling this adds 1 to the mult which will increase the multiplier up to 6 times, any time its called after will just reset its decay
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

    void GunMultDecay()// reduces a counter over time and once empty, resets GunMult, needs to be changed to a coroutine to untie it from frame rate
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

    public void AddComboMult()// can be called to turn ComboMult on or to reset decay
    {
        ComboMult = true;
        ComboMultCounter = GenericMaxCounter;
    }

    void ComboMultDecay()// Counts down until 0, then turns comboMult off // needs to be turned into a coroutine to untie from framerate
    {
        if(ComboMultCounter > 0)
        {
            ComboMultCounter--;
        }
        else
        {
            ComboMult = false;
        }
    }

    //void AddMult()//add a function for every unique multiplier
    //{

    //}

    //void MultDecay()//add a function for every unique multiplier, this should ultimately be a coroutine that removes the multiplier after a certain amount of time (depending on the multiplier)
    //{

    //}

}
