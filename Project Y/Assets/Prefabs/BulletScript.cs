using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 10.0f;
    int lifeTime = 2;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.velocity = transform.localEulerAngles * speed;
        StartCoroutine(BulletGone());
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

    }

    IEnumerator BulletGone()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);

    }
}
