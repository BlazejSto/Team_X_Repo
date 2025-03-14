using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PAnimation : MonoBehaviour
{
    Animator animator;
    GameObject player;// player
    Rigidbody2D body;
    float ySpeed;
    // Start is called before the first frame update
    void Start()
    {
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

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("BackWalk", true);
        }
        else
            animator.SetBool("BackWalk", false);

        if (Input.GetKey(KeyCode.A))
        {
            player.transform.localScale = new Vector3(-2,player.transform.localScale.y, player.transform.localScale.z);
        }
        else
        {
            player.transform.localScale = new Vector3(2, player.transform.localScale.y, player.transform.localScale.z);
        }
    }
}
