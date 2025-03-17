using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    

    private Rigidbody2D rb;
    public ElementEffects effects;

    public float slowMult; //For Coolmetre

    private float horizontalInput;
    private float verticalInput;
    public float speed;// public so an be changed by items
    bool decelerate = false;
    public float decelRate;

    bool canDash = true;
    bool isDashing = false;
    public float dashDistance;
    public float dashTime;
    public float dashDelay;
    float nextDash = 0;

    public AudioSource DashSound;

    GameObject hitbox = default;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        effects = GetComponent<ElementEffects>();
        //effects.IceEffect();

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
            rb.velocity = new Vector2(horizontalInput * (speed * slowMult), verticalInput * (speed * slowMult));//gives the player constant velocity

        if (decelerate == true && isDashing == false)
            rb.velocity = rb.velocity * decelRate;
    }

    private void WASD()
    {
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) == false)
            decelerate = true;

        else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) == true)
        {
            decelerate = false;
            TurnHitboxes(0,0.5f,2.5f, - 0.1f, 0.075f);
            TurnHitboxes(1,0.65f,2.5f, -0.125f, 0.075f);
            TurnHitboxes(2, 0.5f, 2.5f, -0.1f, 0.075f);
            TurnHitboxes(3, 0.65f, 2.5f, -0.125f, 0.075f);
            TurnHitboxes(4, 2, 1.5f, -0.3f, 0.15f);
            TurnHitboxes(5, 2, 1.5f, -0.3f, 0.15f);
            TurnHitboxes(6, 2, 1.5f, -0.3f, 0.15f);
            TurnHitboxes(7, 1.5f, 1f, -0.3f, 0.15f);
            TurnHitboxes(8, 0.5f, 2.5f, -0.1f, 0.25f);
            TurnHitboxes(9, 1.5f, 1, -0.25f, 0.25f);
        }



    }



    void TurnHitboxes(int box,float x, float y,float pox, float poy) //box is the child object position // x and y are used for the localScale for W and S// pox and poy are for positions on W an S
    {
        hitbox = transform.GetChild(box).gameObject;

        if (Input.GetKey(KeyCode.W))
        {
            hitbox.transform.localScale = new Vector3(x,y,1);
            hitbox.transform.localPosition = new Vector3(pox, poy, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            hitbox.transform.localScale = new Vector3(x+.25f, y+.25f, 1);
            hitbox.transform.localPosition = new Vector3(pox - 0.05f, poy-0.5f, 0);
        }
        if (Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.A))
        {
            hitbox.transform.localScale = new Vector3(1, 1, 1);
            hitbox.transform.localPosition = new Vector3(0, 0, 0);
        }
    }

    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && canDash == true)
        {
            isDashing = true;
            canDash = false;
            nextDash = Time.time + dashDelay;

            StartCoroutine(StopDash());
            DashSound.Play();
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
