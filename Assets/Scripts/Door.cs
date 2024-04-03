using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] GameObject TextDontkey, TextAHaveKey;
    public bool ContactPlayer = false;
     
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TextDontkey.SetActive(true);
            ContactPlayer = true;
        }
        else
            TextAHaveKey.SetActive(true);     
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TextDontkey.SetActive(true);
            ContactPlayer = true;
        }
        else
            TextAHaveKey.SetActive(true);   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TextDontkey.SetActive(false);
            ContactPlayer = false;
        }
        else
            TextAHaveKey.SetActive(false);    
    }
}
