using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunBox : MonoBehaviour
{
    int gunState;

    // Update is called once per frame
    void Update()
    {
        gunState = GameObject.FindGameObjectWithTag("Player").GetComponent<pickupGuns>().gunState;

        if (gunState == 0)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);

            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            gameObject.transform.GetChild(3).gameObject.SetActive(false);
            gameObject.transform.GetChild(4).gameObject.SetActive(false);
        }

        else if (gunState == 1)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true);

            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            gameObject.transform.GetChild(3).gameObject.SetActive(false);
            gameObject.transform.GetChild(4).gameObject.SetActive(false);
        }

        else if (gunState == 2)
        {
            gameObject.transform.GetChild(2).gameObject.SetActive(true);

            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(3).gameObject.SetActive(false);
            gameObject.transform.GetChild(4).gameObject.SetActive(false);
        }

        else if (gunState == 3)
        {
            gameObject.transform.GetChild(3).gameObject.SetActive(true);

            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            gameObject.transform.GetChild(4).gameObject.SetActive(false);
        }

        else if (gunState == 4)
        {
            gameObject.transform.GetChild(4).gameObject.SetActive(true);

            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            gameObject.transform.GetChild(3).gameObject.SetActive(false);
        }
    }
}
