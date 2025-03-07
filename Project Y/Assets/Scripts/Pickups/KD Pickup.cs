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

    public AudioSource PickupSound;


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
        PickupSound.Play();//Plays a sound when the pickup is used
    }

    void Inputs()
    {
        interaction = Input.GetAxis("Submit"); //interact key atm == Enter
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
