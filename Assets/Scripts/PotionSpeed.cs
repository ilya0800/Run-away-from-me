using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpeed : MonoBehaviour
{
    [SerializeField]
    Slot _slot;
    [SerializeField]
    GameObject TextPickUp, TextReplace;
    [SerializeField]
    GameObject SlotPotion;
    public static bool PickUpSpeed = false; 

    private void Update()
    {
        ActivePotion();    
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PotionPickUp();
            ReplaceItemPotion(); 
        }
    }

    private void PotionPickUp()
    {
        if (Input.GetKeyDown(KeyCode.E) && Slot._checkSlot)
        {
            gameObject.SetActive(false);
            PickUpSpeed = true;
       //     _slot.PickUpItem();
            DisableText();
        }
    }

    private void ReplaceItemPotion()
    {
        if (Input.GetKeyDown(KeyCode.E) && !Slot._checkSlot)
        {
            _slot.ReplaceItem();
            SlotPotion.gameObject.SetActive(true);
            gameObject.SetActive(false);
            
        }
    }
    private void ActivePotion()
    {
        if (ActivePotionSpeed.ActivePotionSpeedKey())
        {
            Debug.Log("work");
            StartCoroutine(ActiveSpeed());
        }
    }

    IEnumerator ActiveSpeed()
    {
        yield return new WaitForSeconds(3f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        DisableText();
    }

    private void DisableText()
    {
        TextPickUp.SetActive(false);
        TextReplace.SetActive(false);
    } 
}
