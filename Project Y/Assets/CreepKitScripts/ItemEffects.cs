using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class ItemEffects : MonoBehaviour
{
    Rigidbody2D rigidBody;
    public float speed = 5.0f;
    public float jumpForce = 8.0f;
    public float airControlForce = 10.0f;
    public float airControlMax = 1.5f;
    public GameObject BulletPrefab;
    public Transform firePoint;
    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        //if (coll.gameObject.tag == "Bigger")
     //   { bobb
        //    rigidBody.transform.localScale = new Vector3(2, 2, 2);
       //     Destroy(coll.gameObject);
       // }

       // if (coll.gameObject.tag == "Faster")
       // {
       //     speed = 10.0f;
      //      Destroy(coll.gameObject);
      //  }

      //  if (coll.gameObject.tag == "Double")
      //  {

       // }


    }
}


