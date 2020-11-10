using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestTrigger : MonoBehaviour
{

    GameObject player;
    GameObject Canvas;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Canvas = GameObject.FindGameObjectWithTag("EditorOnly");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Canvas.transform.GetChild(5).gameObject.SetActive(true);

            StartCoroutine(Fade());
        }
    }

    public IEnumerator Fade()
    {
        yield return new WaitForSeconds(4f);
        Canvas.transform.GetChild(5).gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}



