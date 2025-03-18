using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyattack : MonoBehaviour
{
    GameObject player;// player

    [SerializeField] private float Damage = 10;

    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Health>() != null)
        {
            Health attack = collider.GetComponent<Health>();
            attack.Damage(Damage);


        }
    }
}
