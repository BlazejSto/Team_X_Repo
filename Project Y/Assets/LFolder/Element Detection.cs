using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementDetection : MonoBehaviour
{
    GameObject player;// player
    ElementEffects element;

    public AudioSource FlameIgnitionSFX;

    // Start is called before the first frame update
    void Start()
    {
        player = Health.GetInstance().gameObject;//finds the player
        element = player.GetComponent<ElementEffects>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Fire")
        {
            element.FireEffect(10);
            Destroy(coll.gameObject);
            FlameIgnitionSFX.Play(); // Plays Flame Ignition sound when player catches on fire
        }

        if(coll.gameObject.tag == "Ice")
        {
            element.IceEffect();
            Destroy(coll.gameObject);
        }

    }



}
