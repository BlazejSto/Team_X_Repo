using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class flameThrowerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    Animator anim;
    public float speed;
    public float wait;
    public float lifespan;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        StartCoroutine("DestroyAfterTime", lifespan);
    }

    private void FixedUpdate()
    {
        rb.velocity = (transform.up * speed); //adds velocity to the bullet object
    }

    private void OnTriggerEnter2D(Collider2D collision) //Trigger when a collision is detected
    {
        if (collision.gameObject.tag == "wall")
            Destroy(gameObject); //destroys the game obejct
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(lifespan);
        Destroy(gameObject);
    }
}
