using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class LightAttack : MonoBehaviour
{
    private int lightAttackDamage = 5;
    private void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.GetComponent<EnemyHealth>() != null)
        {
            EnemyHealth attack = collider.GetComponent<EnemyHealth>();
            attack.Enemy_Damage(lightAttackDamage);
        }
    }

}