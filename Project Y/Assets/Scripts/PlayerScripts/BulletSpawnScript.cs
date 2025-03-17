using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition = new Vector2(0, 0.5f);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition = new Vector2(-0.5f, 0);
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition = new Vector2(0, 0);
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition = new Vector2(0.5f, 0);
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }
    }
}
