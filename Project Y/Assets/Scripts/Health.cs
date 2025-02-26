using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;

    private int MAX_HEALTH = 100;
    void Update()
    {

    }

    public void Damage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative damage");
        }
        else if(amount > 0)
        {
            this.health -= amount;
        }

        if (health < 1)
        {
            Die();
        }
    }
    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
        }

        if(health + amount > MAX_HEALTH)
        {
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
        }
        
    }

    private void Die()
    {
        Debug.Log("I am dead!");
        Destroy(gameObject);
    }
    
}
