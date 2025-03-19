using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private float Enemy_health = 75;

    GameObject player;// player
    public PlayerAttack Damage;//reference to PlayerAttack
    Coolness cool;
    bool iFrames;
    ItemDrops Drops;

    public AudioSource EnemyDeathSFX;


    void Start()
    {
        player = Health.GetInstance().gameObject;//finds the player
        Damage = player.GetComponent<PlayerAttack>();//gets the PlayerAttack from the player
        cool = player.GetComponent<Coolness>();

        Drops = GetComponent<ItemDrops>();
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
        else if (amount > 0 && !iFrames)
        {
            Enemy_health -= amount*(Damage.DamageMult+Damage.ItemDMG);
            iFrames = true;
            StartCoroutine(IFRAMES());
        }

        if (Enemy_health < 1)
        {
            Drops.Drop();
            Enemy_Death();
        }
    }
    private void Enemy_Death()
    {
        Debug.Log("I am dead!");
        EnemyDeathSFX.Play(); // Plays a sound when the enemy dies
        Destroy(gameObject);
    }

    private IEnumerator IFRAMES()
    {
        yield return new WaitForSeconds(0.75f);
        iFrames = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            cool.AddGunMult();
            cool.CoolnessIncrease(50);
            Enemy_Damage(5);
        }

        else if(collision.gameObject.tag == "FlameThrowerFire")
        {
            cool.AddGunMult();
            cool.CoolnessIncrease(0.1f);
            Enemy_Damage(4f);
        }
    }

}
