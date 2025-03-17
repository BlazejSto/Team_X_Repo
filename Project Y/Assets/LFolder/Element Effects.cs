using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementEffects : MonoBehaviour 
{
    GameObject player;// player

    public Coolness Coolness;//reference to Coolness
    public Health health;//reference to Health
    public PlayerScript playerScript;//reference to PlayerScript

    public bool Burning, Freezing;
    public int fireDmg = 1;
    public float slowMult = 1f;

    public float Hypo;
    float IceDMG;
    float FrostCount;
    float FrostCountMax;

    public List<int> burnTickTimer = new List<int>(); //Holds the burn ticks

    public AudioSource PlayerBurningSFX;

    // Start is called before the first frame update
    void Start()
    {
        player = Health.GetInstance().gameObject;//finds the player
        Coolness = player.GetComponent<Coolness>();//gets the Coolness from the player
        health = player.GetComponent<Health>();//gets the Health from the player
        playerScript = player.GetComponent<PlayerScript>();//gets the PlayerScript from the player

        Hypo = 1;
        IceDMG = 1;
        FrostCount = 0;
        FrostCountMax = 10;
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
        PlayerBurningSFX.Play(); // Plays burning sound when the player's burning
        ApplyBurn(fireTick);
        Coolness.Fire();
        
    }
    public void IceEffect()
    {
        Debug.Log("iceE");
        FrostCount = FrostCountMax;
        StartCoroutine(FrostBurn());
        Coolness.Ice();//needs an effect start and end so it can be turned off
    }

    public void HypothermiaDOT()
    {
        Debug.Log("IceH");
        FrostCount = FrostCountMax;
        StartCoroutine(FrostBurn());
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
        if (burnTickTimer.Count <= 0)
        {
            PlayerBurningSFX.Stop(); // When the player stops burning, the burning sound also stops.
            Coolness.FireMultOff();
        }
    }

    IEnumerator FrostBurn()
    {
        while (FrostCount > 0)
        {
            FrostCount--;
            health.Damage(IceDMG * Hypo);
            yield return new WaitForSeconds(0.75f);
        }
        if(FrostCount <= 0)
        {
            Coolness.IceMultOff();
        }

    }
}
