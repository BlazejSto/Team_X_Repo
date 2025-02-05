using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;

    private float horizontalInput;
    private float verticalInput;
    public float speed;
    bool decelerate = false;
    public float decelRate;

    bool canDash = false;
    public float dashDistance;

    public GameObject testAttack;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //GetAxis returns a float between +-1 based on button inputs
        //use GetAxisRaw for snappier movement
        //horizontalInput = Input.GetAxisRaw("Horizontal");
        //verticalInput = Input.GetAxisRaw("Vertical");

        //use standard getAxis for slight acceleration and deccelaration
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.Space) == true)
            canDash = true;
        else
            canDash = false;

        Dash();
        Attack();

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) == false)
            decelerate = true;

        else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) == true)
            decelerate = false;
    }

    //fixed update doesn't depend on framerate - good for physics updates
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * speed, verticalInput * speed);//gives the player constant velocity

        if (decelerate == true)
            rb.velocity = rb.velocity * decelRate;
    }


    private void Dash()
    {
        if (canDash == true)
        {
            Vector3 movementDirection = rb.velocity.normalized;
            transform.position = transform.position+(dashDistance*movementDirection);
        }
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            testAttack.SetActive(true);
        else if (Input.GetKeyUp(KeyCode.Mouse0))
            testAttack.SetActive(false);
    }
}
