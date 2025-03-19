using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PAnimation : MonoBehaviour
{
    Animator animator;
    GameObject player;// player
    Rigidbody2D body;
    PlayerAttack attack;
    pickupGuns guns;
    float ySpeed;
    float Timer;
    // Start is called before the first frame update
    void Start()
    {
        attack = GetComponent<PlayerAttack>();
        guns = GetComponent<pickupGuns>();
        animator = GetComponent<Animator>();
        player = Health.GetInstance().gameObject;//finds the player
        body = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float ySpeed = Mathf.Abs(body.velocity.y);
        animator.SetFloat("FrontWalk", ySpeed);

        float xSpeed = Mathf.Abs(body.velocity.x);
        animator.SetFloat("SideWalk", xSpeed);

    }

    public void FireGun()
    {
        animator.SetBool("FiringGun", true);
        Timer = Time.time;
    }

    private void FixedUpdate()
    {
        animator.SetBool("LightAttacking", attack.lightAttacking);
        animator.SetBool("HeavyAttacking", attack.heavyAttacking);
        animator.SetInteger("Gun",guns.gunState);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Walking", true);
        }
        else
            animator.SetBool("Walking", false);


            if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("BackWalk", true);
        }
        else
            animator.SetBool("BackWalk", false);

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("LeftWalk", true);
        }
        else
            animator.SetBool("LeftWalk", false);



        if (Input.GetKey(KeyCode.W))
        {
            animator.SetInteger("Facing", 0);//0 is facing up
        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetInteger("Facing", 1); //1 is facing left
        }
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetInteger("Facing", 2); //2 is facing down
        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetInteger("Facing", 3); //3 is facing right
        }

        if (Time.time > Timer + 1f)
            animator.SetBool("FiringGun", false);

        if(attack.Melee == "Fists") //fists = 0
        {
            animator.SetInteger("Weapon", 0);
        }

        else if (attack.Melee == "KDFists") //KD = 1
        {
            animator.SetInteger("Weapon", 1);
        }

        else if (attack.Melee == "Knife")// knife = 2
        {
            animator.SetInteger("Weapon", 2);
        }

        else if (attack.Melee == "BBat") //baseball bat = 3
        {
            animator.SetInteger("Weapon", 3);
        }

        else if (attack.Melee == "Crowbar") //baseball bat = 4
        {
            animator.SetInteger("Weapon", 4);
        }


        //if (Input.GetKey(KeyCode.A))
        //{
        //    player.transform.localScale = new Vector3(-2,player.transform.localScale.y, player.transform.localScale.z);
        //}
        //else
        //{
        //    player.transform.localScale = new Vector3(2, player.transform.localScale.y, player.transform.localScale.z);
        //}
    }
}
