using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    Rigidbody2D rigidBody;
    public float speed = 5.0f;
    public float jumpForce = 8.0f;
    public float airControlForce = 10.0f;
    public float airControlMax = 1.5f;
    public GameObject BulletPrefab;
    public Transform firePoint;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireBullet();
        }
    }
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        if (h != 0.0f)
            rigidBody.velocity = new Vector2(h * speed, 0.0f);

    }

    void FireBullet()
    {
        Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
    }
}
