using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupGuns : MonoBehaviour
{
    int gunState = 0;

    /*playerStates
    0 == no gun
    1 == pistol
    2 == smg*/

    bool holdingGun = false;
    bool weaponCheck = false;
    bool pistolCheck = false;
    bool SMGCheck = false;

    float nextShot = 0;
    public float pistolFireRate;
    public float smgFireRate;

    public GameObject bullet;
    public GameObject bulletSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputCheck();

        if(gunState == 1)
            Pistol();

        if (gunState == 2)
            SMG();
    }


    void InputCheck()
    {
        if (Input.GetKeyDown(KeyCode.E) == true && holdingGun == false)
        {
            pickupWeapon();
        }
        else if (Input.GetKeyDown(KeyCode.E) == true && holdingGun == true)
        {
            holdingGun = false;
            gunState = 0;
            pickupWeapon();
        }
    }

    void pickupWeapon()
    {
        if (weaponCheck == true && pistolCheck == true)
        {
            gunState = 1;
            holdingGun = true;
        }

        if(weaponCheck == true && SMGCheck == true)
        {
            gunState = 2;
            holdingGun = true;
        }

        Debug.Log(gunState);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PistolTag")
        {
            weaponCheck = true;
            pistolCheck = true;
        }

        else if(collision.gameObject.tag == "SMGTag")
        {
            weaponCheck = true;
            SMGCheck = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PistolTag")
        {
            weaponCheck = false;
            pistolCheck = false;
        }

        else if (collision.gameObject.tag == "SMGTag")
        {
            weaponCheck = false;
            SMGCheck = false;
        }
    }

    void Pistol()
    {
        if (Input.GetKeyDown(KeyCode.H) && Time.time > nextShot)
        {
            SpawnBullet();
            nextShot = Time.time + pistolFireRate;//gives the player a set fire rate for their weapon
        }
    }

    void SMG()
    {
        if (Input.GetKey(KeyCode.H) && Time.time > nextShot)
        {
            SpawnBullet();
            nextShot = Time.time + smgFireRate;//gives the player a set fire rate for their weapon
        }
    }

    void SpawnBullet()
    {
        Instantiate(bullet, bulletSpawn.transform.position, transform.rotation);//instantiates a bullet at the bulletSpawn gameObject
    }
}
