using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 5;
    private void Start()
    {
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                /*OntriggerEnter2D()*/;
            }
        }
    }
    private void OntriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<Health>() != null)
        {
            Health h = collider.GetComponent<Health>();
            h.Damage(damage);
        }
    }
}
