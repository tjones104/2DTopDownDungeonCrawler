using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed = 20f;
    public float lifeTime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;
    


   
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }
    
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance);
        if (hitInfo.collider != null)
        {
            if(hitInfo.collider.CompareTag("Enemy"))
            {
                Debug.Log("Enemy takes damage!");
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
                DestroyProjectile();
            }
            if(hitInfo.collider.CompareTag("Environment"))
            {
                Debug.Log("Projectile hit environment!");
                DestroyProjectile();
            }
        }
        
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

     void DestroyProjectile()
    {   
        Destroy(gameObject);
    }
}
