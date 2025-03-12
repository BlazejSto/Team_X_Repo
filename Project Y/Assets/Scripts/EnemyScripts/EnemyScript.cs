using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] bool seePlayer = false;

    [SerializeField] int playerDirection;

    public float speed;
    float nextAttack = 0;
    float attackRate = 1.5f;
    float timeToAttack = 0;
    float timer = 0f;

    Transform target;

    GameObject player;
    [SerializeField] GameObject upTarget;
    [SerializeField] GameObject downTarget;
    [SerializeField] GameObject leftTarget;
    [SerializeField] GameObject rightTarget;

    [SerializeField] GameObject topHitbox;
    [SerializeField] GameObject bottomHitbox;
    [SerializeField] GameObject leftHitbox;
    [SerializeField] GameObject rightHitbox;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        seePlayer = gameObject.GetComponent<FOVScript>().canSeePlayer;
        playerDirection = gameObject.GetComponent<FOVScript>().dirToPlayer;

        SetAttackToFalse();

        if (seePlayer == true)
        {
            float playerDistance = Vector2.Distance(transform.position, player.transform.position);
            if (playerDistance < 2)
                Attack();
        }
    }

    private void FixedUpdate()
    {
        if (seePlayer == true)
        {
            MoveToTarget();
        }
    }

    void MoveToTarget()
    {
        if (playerDirection == 1)
        {
            float targetDistance = Vector2.Distance(transform.position, upTarget.transform.position);
            Vector2 targetDirection = (upTarget.transform.position - transform.position).normalized;
            if (targetDistance >= 0.1)
                rb.velocity = targetDirection * speed;
            else
                rb.velocity = new Vector2(0, 0);
        }
        else if (playerDirection == 2)
        {
            float targetDistance = Vector2.Distance(transform.position, downTarget.transform.position);
            Vector2 targetDirection = (downTarget.transform.position - transform.position).normalized;
            if (targetDistance >= 0.1)
                rb.velocity = targetDirection * speed;
            else
                rb.velocity = new Vector2(0, 0);
        }
        else if (playerDirection == 3)
        {
            float targetDistance = Vector2.Distance(transform.position, leftTarget.transform.position);
            Vector2 targetDirection = (leftTarget.transform.position - transform.position).normalized;
            if (targetDistance >= 0.1)
                rb.velocity = targetDirection * speed;
            else
                rb.velocity = new Vector2(0, 0);
        }
        else if (playerDirection == 4)
        {
            float targetDistance = Vector2.Distance(transform.position, rightTarget.transform.position);
            Vector2 targetDirection = (rightTarget.transform.position - transform.position).normalized;
            if (targetDistance >= 0.1)
                rb.velocity = targetDirection * speed;
            else
                rb.velocity = new Vector2(0, 0);
        }
    }

    void Attack()
    {
        if (playerDirection == 1 && Time.time > nextAttack)
        {
            topHitbox.SetActive(true);
            nextAttack = Time.time + attackRate;
        }
        else if (playerDirection == 2 && Time.time > nextAttack)
        {
            bottomHitbox.SetActive(true);
            nextAttack = Time.time + attackRate;
        }
        else if (playerDirection == 3 && Time.time > nextAttack)
        {
            leftHitbox.SetActive(true);
            nextAttack = Time.time + attackRate;
        }
        else if (playerDirection == 4 && Time.time > nextAttack)
        {
           rightHitbox.SetActive(true);
           nextAttack = Time.time + attackRate;
        }
    }

    void SetAttackToFalse()
    {
        timer += Time.deltaTime;

        if (timer >= timeToAttack)
        {
            topHitbox.SetActive(false);
            bottomHitbox.SetActive(false);
            leftHitbox.SetActive(false);
            rightHitbox.SetActive(false);
            timeToAttack = Time.time + 0.5f;
        }
    }
}
