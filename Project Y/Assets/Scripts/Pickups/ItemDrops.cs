using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrops : MonoBehaviour
{
    GameObject Item;

    public List<GameObject> Drops;
    int number;
    int item;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RNG()
    {
        number = Random.Range(0, 4);
        item = Random.Range(0, Drops.Count);
    }

    public void Drop()
    {
        RNG();
        if (number == 3)
        {
            Item = Instantiate(Drops[item], new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
        }
    }

}
