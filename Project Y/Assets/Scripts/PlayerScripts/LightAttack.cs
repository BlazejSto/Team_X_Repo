using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class LightAttack : MonoBehaviour
{
    GameObject player;// player
    public Coolness coolness;//reference to Coolness

    [SerializeField] private float lightAttackDamage = 5;
    [SerializeField] private float cool = 25;

    private void Start()
    {
        player = Health.GetInstance().gameObject;//finds the player
        coolness = player.GetComponent<Coolness>();//gets the Coolness from the player
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<EnemyHealth>() != null)
        {
            EnemyHealth attack = collider.GetComponent<EnemyHealth>();
            attack.Enemy_Damage(lightAttackDamage);
            coolness.CoolnessIncrease(cool);
        }
    }
}