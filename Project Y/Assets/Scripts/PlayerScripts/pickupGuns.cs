using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupGuns : MonoBehaviour
{
    public int gunState = 0;

    /*playerStates
    0 == Revolver
    1 == pistol
    2 == smg
    3 == shotgun
    4 == flamethrower*/

    bool holdingGun = false;
    bool weaponCheck = false;
    bool pistolCheck = false;
    bool SMGCheck = false;
    bool shotgunCheck = false;
    bool flameThrowCheck = false;

    float nextShot = 0;
    public float pistolFireRate;
    public float smgFireRate;
    public float revFireRate;
    public float shotgunFireRate;

    public GameObject bullet;
    public GameObject bulletSpawn;
    public GameObject fire;

    // Update is called once per frame
    void Update()
    {
        InputCheck();

        if (gunState == 0)
            Revolver();

        else if (gunState == 1)
            Pistol();

        else if (gunState == 2)
            SMG();

        else if (gunState == 3)
            Shotgun();

        else if (gunState == 4)
            FlameThrower();
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

        if (weaponCheck == true && SMGCheck == true)
        {
            gunState = 2;
            holdingGun = true;
        }

        if (weaponCheck == true && shotgunCheck == true)
        {
            gunState = 3;
            holdingGun = true;
        }

        if (weaponCheck == true && flameThrowCheck == true)
        {
            gunState = 4;
            holdingGun = true;
        }

        Debug.Log(gunState);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PistolTag")
        {
            weaponCheck = true;
            pistolCheck = true;
        }

        else if (collision.gameObject.tag == "SMGTag")
        {
            weaponCheck = true;
            SMGCheck = true;
        }
        else if (collision.gameObject.tag == "ShotgunTag")
        {
            weaponCheck = true;
            shotgunCheck = true;
        }

        else if (collision.gameObject.tag == "FlameThrowerTag")
        {
            weaponCheck = true;
            flameThrowCheck = true;
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

        else if (collision.gameObject.tag == "ShotgunTag")
        {
            weaponCheck = false;
            shotgunCheck = false;
        }

        else if (collision.gameObject.tag == "FlameThrowerTag")
        {
            weaponCheck = false;
            flameThrowCheck = false;
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

    void Revolver()
    {
        if (Input.GetKeyDown(KeyCode.H) && Time.time > nextShot)
        {
            SpawnBullet();
            nextShot = Time.time + revFireRate;//gives the player a set fire rate for their weapon
        }
    }

    void Shotgun()
    {
        if (Input.GetKeyDown(KeyCode.H) && Time.time > nextShot)
        {
            SpawnPellets();
            nextShot = Time.time + shotgunFireRate;//gives the player a set fire rate for their weapon
        }
    }

    void FlameThrower()
    {
        if (Input.GetKey(KeyCode.H))
            SpawnFire();
    }

    void SpawnBullet()
    {
        Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);//instantiates a bullet at the bulletSpawn gameObject
    }

    void SpawnPellets()
    {
        for (int i = 0; i < 5; i++)
        {
            float spread = Random.Range(-15f, 15f);//randomises spread
            Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation * Quaternion.Euler(0, 0, spread));
        }
    }

    void SpawnFire()
    {
        float fireSpread = Random.Range(-20f, 20f);//randomises spread
        Instantiate(fire, bulletSpawn.transform.position, bulletSpawn.transform.rotation * Quaternion.Euler(0, 0, fireSpread));
    }
}
