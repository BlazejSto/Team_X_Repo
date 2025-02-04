using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coolness : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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


    public void CoolnessIncrese()//called externally on an action or effect to increase coolness
    {

    }

    void RankCheck()//updates the player's rank based on their coolness
    {

    }

    void Decay()//rate at which coolness decays, CANNOT go below rank D through decay, so D should be 0, and each rank should have a 'unique' decay (some may be shared) so have code to check which decay is run
    {

    }

    void MultCalc()//adds all multipliers together
    {

    }

    void AddMult()//add a function for every unique multiplier
    {

    }

    void MultDecay()//add a function for every unique multiplier, this should ultimately be a coroutine that removes the multiplier after a certain amount of time (depending on the multiplier)
    {

    }

}
