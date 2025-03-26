using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HypoUI : MonoBehaviour
{
    int hypo;

    // Update is called once per frame
    void Update()
    {
        hypo = GameObject.FindGameObjectWithTag("Player").GetComponent<Coolness>().Hypothermia;

        if (hypo == 0)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            gameObject.transform.GetChild(3).gameObject.SetActive(false);
            gameObject.transform.GetChild(4).gameObject.SetActive(false);
            gameObject.transform.GetChild(5).gameObject.SetActive(false);
        }

        else if (hypo == 1)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);

            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            gameObject.transform.GetChild(3).gameObject.SetActive(false);
            gameObject.transform.GetChild(4).gameObject.SetActive(false);
            gameObject.transform.GetChild(5).gameObject.SetActive(false);
        }

        else if (hypo == 2)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(2).gameObject.SetActive(true);

            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(3).gameObject.SetActive(false);
            gameObject.transform.GetChild(4).gameObject.SetActive(false);
            gameObject.transform.GetChild(5).gameObject.SetActive(false);
        }

        else if (hypo == 3)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(3).gameObject.SetActive(true);

            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            gameObject.transform.GetChild(4).gameObject.SetActive(false);
            gameObject.transform.GetChild(5).gameObject.SetActive(false);
        }

        else if (hypo == 4)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(4).gameObject.SetActive(true);

            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            gameObject.transform.GetChild(3).gameObject.SetActive(false);
            gameObject.transform.GetChild(5).gameObject.SetActive(false);
        }

        else if (hypo == 5)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(5).gameObject.SetActive(true);

            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            gameObject.transform.GetChild(3).gameObject.SetActive(false);
            gameObject.transform.GetChild(4).gameObject.SetActive(false);
        }
    }
}
