using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyEnemy : MonoBehaviour
{
    private float health = 100;

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("playerAttack"))
        {
            health = health - 20;
            Debug.Log("Dummy Health: " + health);
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("playerAttack"))
        {
            health = health - 20;
            Debug.Log("Dummy Health: " + health);
        }
    }
}
