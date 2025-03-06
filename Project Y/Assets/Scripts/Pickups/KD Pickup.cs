using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KDPickup : MonoBehaviour
{
    GameObject player;// player
    public PlayerAttack Damage;//reference to PlayerAttack

    bool interactable;

    float interaction;

    [SerializeField] private string Weapon = "KDFists";


    // Start is called before the first frame update
    void Start()
    {
        player = Health.GetInstance().gameObject;//finds the player
        Damage = player.GetComponent<PlayerAttack>();//gets the PlayerAttack from the player
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
    }

    void FixedUpdate()
    {
        if (interactable && interaction > 0) //when the player is able to interact and presses the interact key
        {
            Pickup(); //picks weapon up
        }
    }

    void Pickup()
    {
        Damage.Melee = Weapon;//changes Melee variable to the new weapon
        Destroy(gameObject);//Destroys pickup once used
    }

    void Inputs()
    {
        interaction = Input.GetAxis("Submit"); //interact key atm == Enter
        Debug.Log(interaction);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")//player overlapping the boxcollider for the card
        {
            interactable = true;//can interact
            Debug.Log("interatable");
        }
    }

    void OnTriggerExit2D(Collider2D coll)//player no longer overlapping the boxcollider for the card
    {
        if (coll.gameObject.tag == "Player")
        {
            interactable = false;//cannot interact
        }
    }
}
