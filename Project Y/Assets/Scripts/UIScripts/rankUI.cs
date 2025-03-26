using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rankUI : MonoBehaviour
{
    char rank;

    // Update is called once per frame
    void Update()
    {
        rank = GameObject.FindGameObjectWithTag("Player").GetComponent<Coolness>().Rank;

        if (rank == 'f')
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);

            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            gameObject.transform.GetChild(3).gameObject.SetActive(false);
            gameObject.transform.GetChild(4).gameObject.SetActive(false);
            gameObject.transform.GetChild(5).gameObject.SetActive(false);
            gameObject.transform.GetChild(6).gameObject.SetActive(false);
        }

        else if (rank == 'd')
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true);

            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            gameObject.transform.GetChild(3).gameObject.SetActive(false);
            gameObject.transform.GetChild(4).gameObject.SetActive(false);
            gameObject.transform.GetChild(5).gameObject.SetActive(false);
            gameObject.transform.GetChild(6).gameObject.SetActive(false);
        }

        else if (rank == 'c')
        {
            gameObject.transform.GetChild(2).gameObject.SetActive(true);

            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(3).gameObject.SetActive(false);
            gameObject.transform.GetChild(4).gameObject.SetActive(false);
            gameObject.transform.GetChild(5).gameObject.SetActive(false);
            gameObject.transform.GetChild(6).gameObject.SetActive(false);
        }

        else if (rank == 'b')
        {
            gameObject.transform.GetChild(3).gameObject.SetActive(true);

            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            gameObject.transform.GetChild(4).gameObject.SetActive(false);
            gameObject.transform.GetChild(5).gameObject.SetActive(false);
            gameObject.transform.GetChild(6).gameObject.SetActive(false);
        }

        else if (rank == 'a')
        {
            gameObject.transform.GetChild(4).gameObject.SetActive(true);

            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            gameObject.transform.GetChild(3).gameObject.SetActive(false);
            gameObject.transform.GetChild(5).gameObject.SetActive(false);
            gameObject.transform.GetChild(6).gameObject.SetActive(false);
        }

        else if (rank == 's')
        {
            gameObject.transform.GetChild(5).gameObject.SetActive(true);

            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            gameObject.transform.GetChild(3).gameObject.SetActive(false);
            gameObject.transform.GetChild(4).gameObject.SetActive(false);
            gameObject.transform.GetChild(6).gameObject.SetActive(false);
        }

        else if (rank == 'h')
        {
            gameObject.transform.GetChild(6).gameObject.SetActive(true);

            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            gameObject.transform.GetChild(3).gameObject.SetActive(false);
            gameObject.transform.GetChild(4).gameObject.SetActive(false);
            gameObject.transform.GetChild(5).gameObject.SetActive(false);
        }
    }
}
