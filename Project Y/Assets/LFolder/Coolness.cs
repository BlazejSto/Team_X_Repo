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

    float GunMult;
    public List<float> GunMultList;
    float GunMultCounter;
    float GunMultMaxCount;

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
        GunMultList.Add(5f);//shot 3, etc.
        GunMultList.Add(8f);
        GunMultList.Add(13f);
        GunMultList.Add(21f);//shot 6
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
    }

    void RankCheck()//updates the player's rank based on their coolness
    {

    }

    void Decay()//rate at which coolness decays, CANNOT go below rank D through decay, so D should be 0, and each rank should have a 'unique' decay (some may be shared) so have code to check which decay is run
    {
        coolness -= decayrate;
    }

    float MultCalc()//adds all multipliers together
    {
        float mult;

        mult = 0;

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
