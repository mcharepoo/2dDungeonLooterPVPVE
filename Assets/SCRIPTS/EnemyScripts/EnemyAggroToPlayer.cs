using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggroToPlayer : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float aggroDistance;
    

    [SerializeField] bool isAggrod = false;
    public bool canCheckDistance = true;

    [SerializeField] Animator animator;

    [SerializeField] Rigidbody2D rb;

    [SerializeField] float moveSpeed;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("EnemyAggroTransform").transform;

    }

    void Update()
    {
        checkDistance();
        WalkAnimation();
    }
    void FixedUpdate()
    {
        RigidBodyControl();
    }

    void checkDistance()
    {
        if (playerTransform != null && canCheckDistance)
        {
            float distance = Vector2.Distance(playerTransform.position, transform.position);
            if (distance < aggroDistance)
            {
                isAggrod = true;
            }   // You can now use the 'distance' variable in your game logic.
            
        }
        else
        {
            isAggrod = false;
        }
    }

    void WalkAnimation()
    {
        if(isAggrod)
        {
            animator.SetBool("Walk", isAggrod);
        }
        else
        {
            animator.SetBool("Walk", isAggrod);
        }
    }

    void RigidBodyControl()
    {
        if(isAggrod)
        {
            if (playerTransform != null)
            {
                Vector2 direction = playerTransform.position - transform.position;
                direction.Normalize();

                // Move the enemy towards the player
                rb.velocity = direction * moveSpeed;
            }
            else
            {
                // Player reference is null; do something else, like patrolling or idling
                rb.velocity = Vector2.zero;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
