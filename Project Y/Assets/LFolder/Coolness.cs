using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coolness : MonoBehaviour
{
    float coolness;
    float decayrate;

    char Rank;

    int Hypothermia;

    int GunMult;
    public List<float> GunMultList;
    float GunMultCounter;
    float GunMultMaxCount;

    float GenericMaxCounter;

    bool ComboMult;
    float ComboMultVal;
    float ComboMultCounter;

    bool FireMult;
    bool IceMult;

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

        FireMult = false;
        IceMult = false;

        Hypothermia = 0;
    }

    // Update is called once per frame
    void Update()
    {
        RankCheck();

        if(Rank == 'h')
        {
            HypothermiaCheck();
        }

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


    public void CoolnessIncrease(float actionval)//called externally on an action or effect to increase coolness
    {
        
        float mult = MultCalc();
        coolness = coolness + (actionval * mult);

        if (coolness < -1000)// can't go below -1000
        {
            coolness = -1000;
        }

        if (coolness > 6000)
        {

        }

        if(coolness > 7000)// can't go above 6000
        {
            coolness = 7000;
        }
        
    }

    void RankCheck()//updates the player's rank based on their coolness
    {
        if (coolness < 0)//Less than 0 is rank F
        {
            Rank = 'f';
        }

        else if (coolness >= 0 && coolness < 1000)// 0 - 999 is D, 1000 
        {
            Rank = 'd';
        }

        else if (coolness >= 1000 && coolness < 2000)// 1000 - 1999 is C, 1000
        {
            Rank = 'c';
        }

        else if (coolness >= 2000 && coolness < 3500)// 2000 - 3499 is B, 1500
        {
            Rank = 'b';
        }

        else if (coolness >= 3500 && coolness < 5000)// 3500 - 4999 is A. 1500
        {
            Rank = 'a';
        }

        else if (coolness >= 5000)// 5000 + is S 1000
        {
            Rank = 's';
        }

        else if (coolness >= 6000)
        {
            Rank = 'h';
        }
    }

    void HypothermiaCheck()
    {
        if(coolness > 6100)
        {
            Hypothermia = 1;
        }
        if (coolness > 6200)
        {
            Hypothermia = 2;
        }
        if (coolness > 6300)
        {
            Hypothermia = 3;
        }
        if (coolness > 6400)
        {
            Hypothermia = 4;
        }
        if (coolness > 6500)
        {
            Hypothermia = 5;
        }
    }

    void HypothermiaEffects()
    {
        if (Hypothermia >= 1)
        {
            //Damage received and dealt increased (1.5x?)  <----need public stat to change
            //Item efficiency for cold items now 1 <---- need public stat to change (sprint 3?)
            //Ice visual effects stage 1 (HUD effects)
        }
        if(Hypothermia >= 2)
        {
            //Damage received and dealt increased further (now 2x?) <---- need public stat to change
            //Ice visual effects stage 2(HUD effects)
        }
        if (Hypothermia >= 3)
        {
            //Item efficiency for cold now 2 <---- need public stat to change (sprint 3?)
            //Health Recovery of any kind reduced (0.75x?) <---- need public stat to change
            //Ice visual effects stage 3(HUD effects)
        }
        if (Hypothermia >= 4)
        {
            //Speed Reduced <---- need public stat to change
            //Warning to the player about High Hypothermia? (HUD effects)
        }
        if (Hypothermia > 5)
        {
            //The damaging effect of Hypothermia (Death or DOT) <---- need public stat to change
            //Ice visual effects stage 4 (HUD effects)
        }
    }

    void Decay()//rate at which coolness decays, CANNOT go below rank D through decay, so D should be 0, and each rank should have a 'unique' decay (some may be shared) so have code to check which decay is run
    {
        if (coolness > 0)
        {
            coolness -= decayrate;
        }
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

        if (FireMult)
        {
            mult *= 0.8f;
        }

        if(IceMult)
        {
            mult *= 1.2f;
        }

        return mult;
    }

    public void AddGunMult()//calling this adds 1 to the mult which will increase the multiplier up to 6 times, any time its called after will just reset its decay
    {
        if (GunMult < 6)
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

    public void Fire()//when the player is set on fire, call this
    {
        if(Rank == 'd')//if at rank D and is set on fire, then the players rank becomes F and is set to -750
        {
            coolness = -750;
            Rank = 'f';
        }

        else if (Rank == 'h')//if the player is in Hypothermia and set on fire, their coolness is reduced dramatically and their hypothermia stacks are all lost
        {
            coolness -= 2000;
            Hypothermia = 0;
        }

        else//most of the time the player will only lose 1500 coolness when set on fire
        {
            coolness -= 1500;
        }

        if (!IceMult)// If FireMult and IceMult activate at the same time they cancel each other out
        {
            FireMult = true;
        }
        else
        {
            IceMult = false;
        }
    }

    public void FireMultOff()//when the fire effect ends, call this
    {
        FireMult = false;
    }

    public void Ice()//when the player is hit with ice, call this
    {
        if (Rank == 'f')//if the players rank is f and is hit with ice, they are given a boost up to C skipping D
        {
            Rank = 'c';
            coolness = 1250;
        }

        else if (Rank == 'h')//if the player is hit with ice in Hypothermia, they are given coolness. Might change to max out Hypothermia in the future, but its set to this for now for testing
        {
            coolness += 500;
        }

        else//most of the time the player will gain 1500 coolness when hit with ice
        {
            coolness += 1500;
        }

        if (!FireMult)// If FireMult and IceMult activate at the same time they cancel each other out
        {
            IceMult = true;
        }
        else
        {
            FireMult = false ;
        }
    }

    public void IceMultOff()//when the ice effect on the player has ended, call this
    {
        IceMult = false;
    }

    //void AddMult()//add a function for every unique multiplier
    //{

    //}

    //void MultDecay()//add a function for every unique multiplier, this should ultimately be a coroutine that removes the multiplier after a certain amount of time (depending on the multiplier)
    //{

    //}

}
