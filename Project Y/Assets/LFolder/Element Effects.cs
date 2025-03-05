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

    public List<int> burnTickTimer = new List<int>();

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
        if (Burning == true)
        {
            FireEffect();
        }
    }

    public void FireEffect()
    {
        
        //Coolness.Fire();
        ApplyBurn(5);
        health.Damage(fireDmg);
        
        
        
    }
    public void IceEffects()
    {
        slowMult = 0.90f;
    }

    public void ApplyBurn(int ticks)
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
            health.Damage(fireDmg);
            burnTickTimer.RemoveAll(tick => tick == 0);
            yield return new WaitForSeconds(0.75f);
        }
    }
}
