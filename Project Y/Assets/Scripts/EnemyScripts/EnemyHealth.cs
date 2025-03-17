using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private float Enemy_health = 10;

    GameObject player;// player
    public PlayerAttack Damage;//reference to PlayerAttack
    bool iFrames;
    ItemDrops Drops;

    void Start()
    {
        player = Health.GetInstance().gameObject;//finds the player
        Damage = player.GetComponent<PlayerAttack>();//gets the PlayerAttack from the player

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
            Enemy_Damage(5);
        }

        else if(collision.gameObject.tag == "FlameThrowerFire")
        {
            Enemy_Damage(4f);
        }
    }

}
