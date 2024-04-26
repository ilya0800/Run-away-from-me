using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpeed : MonoBehaviour, ITextForItem
{
    [SerializeField]
    Slot _slot;
    [SerializeField]
    private GameObject _textPickUp;
    [SerializeField]
    private GameObject _textReplace;
    [SerializeField]
    GameObject SlotPotion;
    public static bool PickUpSpeed = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ShowText();
            PotionPickUp();
            ReplaceItemPotion(); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        HideText();    
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

    public void ShowText()
    {
        if (Slot._checkSlot)
        {
            _textReplace.SetActive(false);
            _textPickUp.SetActive(true);
        }
        else if (!Slot._checkSlot)
        {
            _textPickUp.SetActive(false);
            _textReplace.SetActive(true);
        }
    }

    public void HideText()
    {
        _textReplace.SetActive(false);
        _textPickUp.SetActive(false);
    }
}
