using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    
    public float baseMoveSpeed = 10f;
    private float currentMoveSpeed;

    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;

    private CharacterInventory characterInventory;

    void Start()
    {
        characterInventory = new CharacterInventory();
    }

    void Update()
    {
        //code to test if inventory updates, and removes
        if(Input.GetKeyDown(KeyCode.Space))
        {
            characterInventory.listOfItems();
        }
        else if(Input.GetKeyDown(KeyCode.Q))
        {
            characterInventory.removeItem("IncreaseDamage", this.gameObject);
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            characterInventory.removeItem("MovementUp", this.gameObject);
                
        }
        //end of test code


        Inputs();
        Animate();
    }


    void FixedUpdate()
    {
        Move();
    }

    private void Inputs()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        if (movement.magnitude > 1.0f)
        {
            movement.Normalize();
        } 
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * currentMoveSpeed * Time.fixedDeltaTime);
    }


    private void Animate()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Item"))
        {
            add2Inventory(collision.GetComponent<Collectables>().item);
            Destroy(collision.gameObject);
            gameObject.GetComponent<CalculateCharacterStats>().calcAll();
        }
    }

    public CharacterInventory getInventory()
    {
        return characterInventory;
    }

    public void setMovementSpeed(float newMoveSpeed)
    {
        
        currentMoveSpeed = newMoveSpeed;
        Debug.Log("New ms " + currentMoveSpeed);
    }

    public float getMovementSpeed()
    {
        return baseMoveSpeed;
    }

    public void add2Inventory(Item itemGameObject)
    {
        characterInventory.addItem(itemGameObject);
    }

    public IEnumerator waiting(GameObject gO)
    {
        int waitTime = 3;
        Vector2 randomDir = Random.insideUnitCircle;
        gO.GetComponent<BoxCollider2D>().enabled = false;
        gO.GetComponent<Rigidbody2D>().AddForce(randomDir * 5f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(waitTime);
        gO.GetComponent<BoxCollider2D>().enabled = true;
    }
    
}
