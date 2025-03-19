using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private static Health instance; //decalares instance for reference to player
    public static Health GetInstance() { return instance; }//reference that can be accessed by other objects


    [SerializeField] private float Player_health = 100;

    private float Player_MAX_HEALTH = 100;

    public float DamageMult = 1; //For Coolmetre

    bool iFrames;

    public AudioSource PlayerDeathSFX;



    private void Awake()
    {
        instance = this;//creates the instance
    }

    void Update()
    {

    }

    public void Damage(float amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative damage");
        }
        else if (amount > 0 && !iFrames)
        {
            this.Player_health -= (amount * DamageMult) ;
            iFrames = true ;
            StartCoroutine(IFRAMES());
        }

        if (Player_health < 1)
        {
            PlayerDeath();
        }
    }
    public void Heal(float amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
        }

        if (Player_health + amount > Player_MAX_HEALTH)
        {
            Player_health = Player_MAX_HEALTH;
        }
        else
        {
            Player_health += amount;
        }

    }

    private void PlayerDeath()
    {
        Debug.Log("I am dead!");
        //PlayerDeathSFX.Play(); // Plays a sound when the player dies
        Destroy(gameObject);
    }

    private IEnumerator IFRAMES()
    {
        yield return new WaitForSeconds(0.75f);
        iFrames = false;
    }
}
