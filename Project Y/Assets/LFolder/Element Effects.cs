using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementEffects : MonoBehaviour 
{
    public Coolness Coolness;
    public Health health;
    public PlayerScript playerScript;

    public bool Burning, Freezing;
    public int fireDmg = 1;
    public float slowMult = 1f;

    public List<int> burnTickTimer = new List<int>(); //Holds the burn ticks

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

    }
    public void FireEffect(int fireTick) 
    {  
        ApplyBurn(fireTick);
        
    }
    public void IceEffects()
    {
        
    }

    public void ApplyBurn(int ticks) //Adds the ticks into Burnticktimer list
                                     //To use call ApplyBurn and pass it a number of ticks it should burn for
    {
        if (burnTickTimer.Count <= 0) 
        {
            burnTickTimer.Add(ticks);
            StartCoroutine(Burn());
        }
        else
        {
            burnTickTimer.Add(ticks);
        }
    }
    IEnumerator Burn() 
    {
        while (burnTickTimer.Count > 0)
        {
            for (int i = 0; i < burnTickTimer.Count; i++) 
            {
                burnTickTimer[i]--;
            }
            health.Damage(fireDmg); //Calls Damage method to deal damage while burn is applied
            burnTickTimer.RemoveAll(tick => tick == 0); //Removes all parts of the list once its empty
            yield return new WaitForSeconds(0.75f); //Waits for set amount of seconds before running it again
        }
    }
}
