using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;

public class FOVScript : MonoBehaviour
{

    public float viewRadius;

    public bool canSeePlayer;

    //This set of variable return true depending on which direction the player is from the enemy
    public bool playerIsUp;
    public bool playerIsDown;
    public bool playerIsLeft;
    public bool playerIsRight;
    public int dirToPlayer = 0; //0 = null, 1 = up, 2 = down, 3 = left, 4 = right

    public LayerMask playerMask;
    public LayerMask obstacleMask;

    GameObject player;

    void Start()
    {
        StartCoroutine("DelayFOV", 0.2f);
        player = GameObject.FindGameObjectWithTag("Player");
    }


    IEnumerator DelayFOV(float delay)   //used to prevent script from running hundreds of times a second, improves performance
    {
        while (true)
        {
            yield return new WaitForSeconds(delay); //delays exection of FindPlayer for 0.2 seconds
            FindPlayer();
        }
    }

    void FindPlayer()
    {
        canSeePlayer = false;
        playerIsUp = false;
        playerIsDown = false;
        playerIsLeft = false;
        playerIsRight = false;
        Collider2D[] playerInRadius = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), viewRadius, playerMask);//creates an overlap circle at the enemy's position that checks for objects with playerMask
        for (int i = 0; i < playerInRadius.Length; i++)//for every object within the overlap circle
        {
            Transform target = playerInRadius[i].transform;//gets the transform of the overlapping object
            Vector2 playerDirection = (target.position - transform.position).normalized;//gets the direction of the overlapping object
            if (Vector2.Angle(transform.up, playerDirection) < 45)//gets an unsigned angle based on playerDirection, returns true if the angle is less than half of view angle (for example: + or - 45 degrees from the transform.up)
            {
                float playerDistance = Vector2.Distance(transform.position, target.position);//gets the distance to the player
                if (!Physics2D.Raycast(transform.position, playerDirection, playerDistance, obstacleMask))//sends a raycast in the player direction for playerDistance, raycast can collide with objects of the obstacleMask
                {
                    canSeePlayer = true;//can see player if raycast is successful
                    playerIsUp = true;
                    dirToPlayer = 1;
                    Debug.Log("Up");
                }
            }

            else if (Vector2.Angle(transform.up, playerDirection) > 135)
            {
                float playerDistance = Vector2.Distance(transform.position, target.position);
                if (!Physics2D.Raycast(transform.position, playerDirection, playerDistance, obstacleMask))
                {
                    canSeePlayer = true;
                    playerIsDown = true;
                    dirToPlayer = 2;
                    Debug.Log("Down");
                }
            }

            else if (Vector2.Angle(transform.right, playerDirection) < 45)
            {
                float playerDistance = Vector2.Distance(transform.position, target.position);
                if (!Physics2D.Raycast(transform.position, playerDirection, playerDistance, obstacleMask))
                {
                    canSeePlayer = true;
                    playerIsRight = true;
                    dirToPlayer = 4;
                    Debug.Log("Right");
                }
            }

            else if (Vector2.Angle(transform.right, playerDirection) > 135)
            {
                float playerDistance = Vector2.Distance(transform.position, target.position);
                if (!Physics2D.Raycast(transform.position, playerDirection, playerDistance, obstacleMask))
                {
                    canSeePlayer = true;
                    playerIsLeft = true;
                    dirToPlayer = 3;
                    Debug.Log("Left");
                }
            }
        }
    }
}