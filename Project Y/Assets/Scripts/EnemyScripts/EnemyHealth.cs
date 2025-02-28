using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int Enemy_health = 10;
    void Update()
    {

    }

    public void Enemy_Damage(int amount)
    {

        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative damage");
        }
        else if (amount > 0)
        {
            Enemy_health -= amount;
        }

        if (Enemy_health < 1)
        {
            Enemy_Death();
        }
    }
    private void Enemy_Death()
    {
        Debug.Log("I am dead!");
        Destroy(gameObject);
    }

}
