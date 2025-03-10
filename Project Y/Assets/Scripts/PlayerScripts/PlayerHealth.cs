using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private static Health instance; //decalares instance for reference to player
    public static Health GetInstance() { return instance; }//reference that can be accessed by other objects


    [SerializeField] private int Player_health = 100;

    private int Player_MAX_HEALTH = 100;



    private void Awake()
    {
        instance = this;//creates the instance
    }

    void Update()
    {

    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative damage");
        }
        else if (amount > 0)
        {
            this.Player_health -= amount;
            
        }

        if (Player_health < 1)
        {
            PlayerDeath();
        }
    }
    public void Heal(int amount)
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
        Destroy(gameObject);
    }

}
