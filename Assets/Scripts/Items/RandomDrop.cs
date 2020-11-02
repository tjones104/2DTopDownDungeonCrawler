using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDrop : MonoBehaviour
{
    [SerializeField] private Item IncreaseDamage;
    [SerializeField] private Item MovementUp;

    public Item getRandomItem()
    {
        int rand = Random.Range(0,100);
        // if(rand <= 50)
        // {
        //     return null;
        // }
        if(rand > 50 && rand <= 85)
        {
            Debug.Log("MovementUp drops from " + gameObject.name);
            return MovementUp;
        }
        else if(rand > 85 && rand <= 100)
        {
            Debug.Log("IncreaseDamage drops from " + gameObject.name);
            return IncreaseDamage;
        }
        Debug.Log("Nothing drops from " + gameObject.name);
        return null;
    }

    public void dropRandomItem()
    {
        Item item = getRandomItem();
        if(item != null)
        {
            GameObject gO = GameObject.Instantiate(item.itemPrefab, gameObject.transform.position, item.itemPrefab.transform.rotation);
        }
    }

    //test code
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            dropRandomItem();
        }
    }
}
