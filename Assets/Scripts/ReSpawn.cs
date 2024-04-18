using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawn : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fire"))
        {
            gameObject.transform.position = new Vector2(Random.Range(-10, 16), Random.Range(12, -6.90f));
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Fire"))
        {
            gameObject.transform.position = new Vector2(Random.Range(-10, 16), Random.Range(12, -6.90f));
        }
    }
}
