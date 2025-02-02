using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;

    private float horizontalInput;
    private float verticalInput;
    public float speed;

    bool canDash = false;
    public float dashDistance;

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
    }

    //fixed update doesn't depend on framerate - good for physics updates
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * speed, verticalInput * speed);//gives the player constant velocity
    }


    private void Dash()
    {
        if (canDash == true)
        {
            Vector3 movementDirection = rb.velocity.normalized;
            transform.position = transform.position+(dashDistance*movementDirection);
        }
    }
}
