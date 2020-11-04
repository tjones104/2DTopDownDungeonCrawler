using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public AIPath aiPath;
    public int health;
    public GameObject deathEffect;
    public bool IsMoving;
    public Animator animator;
    public int damage = 10;
    public Transform player;
    public float targetRange;

    void Start()
    {
        aiPath.canSearch = false;
    }

    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            animator.SetBool("IsMoving", true);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);

            animator.SetBool("IsMoving", true);
        }
        else if (aiPath.desiredVelocity.x == 0f)
        {
            animator.SetBool("IsMoving", false);
        }

        if (health <=0)
        {
            gameObject.GetComponent<RandomDrop>().dropRandomItem();
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Debug.Log("Enemy Dead");
            Destroy(gameObject);
            Destroy(transform.parent.gameObject);
        }

        FindTarget();
    }

    private void FindTarget()
    {
        Debug.Log(Vector3.Distance(transform.position, player.position));
        float targetRange = 14f;
        if(Vector3.Distance(transform.position, player.position) < targetRange)
        {
            
            aiPath.canSearch = true;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player is colliding");
            collision.gameObject.GetComponent<PlayerController>().takeDamage(damage);
        }
    }
}
