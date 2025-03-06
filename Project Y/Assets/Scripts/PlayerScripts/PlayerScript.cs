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

    bool canDash = true;
    bool isDashing = false;
    public float dashDistance;
    public float dashTime;
    public float dashDelay;
    float nextDash = 0;


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

        WASD();
        Dash();
    }

    //fixed update doesn't depend on framerate - good for physics updates
    private void FixedUpdate()
    {
        if(isDashing == false)
            rb.velocity = new Vector2(horizontalInput * speed, verticalInput * speed);//gives the player constant velocity

        if (decelerate == true && isDashing == false)
            rb.velocity = rb.velocity * decelRate;
    }

    private void WASD()
    {
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) == false)
            decelerate = true;

        else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) == true)
            decelerate = false;
    }

    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && canDash == true)
        {
            isDashing = true;
            canDash = false;
            nextDash = Time.time + dashDelay;

            StartCoroutine(StopDash());
            Debug.Log("Is dashing");
        }

        if(isDashing)
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * dashDistance, Input.GetAxisRaw("Vertical") * dashDistance);

        if (Time.time > nextDash)
            canDash = true;
    }

    private IEnumerator StopDash()
    {
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
    }
}
