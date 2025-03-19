using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeBox : MonoBehaviour
{
    string meleeState;

    // Update is called once per frame
    void Update()
    {
        meleeState = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>().Melee;

        if (meleeState == "Fists")
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);

            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            gameObject.transform.GetChild(3).gameObject.SetActive(false);
            gameObject.transform.GetChild(4).gameObject.SetActive(false);
        }

        else if (meleeState == "Knife")
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true);

            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            gameObject.transform.GetChild(3).gameObject.SetActive(false);
            gameObject.transform.GetChild(4).gameObject.SetActive(false);
        }

        else if (meleeState == "KDFists")
        {
            gameObject.transform.GetChild(2).gameObject.SetActive(true);

            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(3).gameObject.SetActive(false);
            gameObject.transform.GetChild(4).gameObject.SetActive(false);
        }

        else if (meleeState == "BBat")
        {
            gameObject.transform.GetChild(3).gameObject.SetActive(true);

            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            gameObject.transform.GetChild(4).gameObject.SetActive(false);
        }

        else if (meleeState == "Crowbar")
        {
            gameObject.transform.GetChild(4).gameObject.SetActive(true);

            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            gameObject.transform.GetChild(3).gameObject.SetActive(false);
        }
    }
}

