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
