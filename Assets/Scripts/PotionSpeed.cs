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
            PickUpSpeed = true;
            _slot.PickUpItem();
            gameObject.SetActive(false);
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
    IEnumerator ActiveSpeed()
    {
        yield return new WaitForSeconds(3f);
    }
}
