using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemEffects : MonoBehaviour
{
    Rigidbody2D rigidBody;
    public float speed = 5.0f;
    public float jumpForce = 8.0f;
    public float airControlForce = 10.0f;
    public float airControlMax = 1.5f;
    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        //This piece of code will increase the size of the player when the E key is pressed down
        if (Input.GetKeyDown(KeyCode.E))
        {
            rigidBody.transform.localScale = new Vector3(2, 2, 2);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            speed = 7.0f;
        }
    }
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        if (h != 0.0f)
            rigidBody.velocity = new Vector2(h * speed, 0.0f);
    }
}

