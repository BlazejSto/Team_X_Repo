using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private float Enemy_health = 10;

    GameObject player;// player
    public PlayerAttack Damage;//reference to PlayerAttack


    void Start()
    {
        player = Health.GetInstance().gameObject;//finds the player
        Damage = player.GetComponent<PlayerAttack>();//gets the PlayerAttack from the player
    }

    void Update()
    {

    }

    public void Enemy_Damage(float amount)
    {

        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative damage");
        }
        else if (amount > 0)
        {
            Enemy_health -= amount*Damage.DamageMult;
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
