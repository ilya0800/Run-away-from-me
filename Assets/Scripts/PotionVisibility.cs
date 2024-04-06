using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public partial class Potion : MonoBehaviour
{
    [SerializeField]
    GameObject Darkness;
    [SerializeField]
    Slot _slot;
    [SerializeField]
    GameObject _textPickUpItem;
    [SerializeField]
    GameObject _textReplaceItem;
    [SerializeField]
    GameObject SlotPotion;
    public static bool PickUpVisibility = false;


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
        if (Input.GetKey(KeyCode.E) && Slot._checkSlot)
        {
            PickUpVisibility = true; 
            _slot.PickUpItem();

            gameObject.SetActive(false);
            DisableText();
            Debug.Log("pic");
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        DisableText();
    }

    private void DisableText()
    {
        _textReplaceItem.SetActive(false);
        _textPickUpItem.SetActive(false);
    }
}
