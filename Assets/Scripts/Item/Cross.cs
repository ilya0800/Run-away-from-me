using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Cross : MonoBehaviour, ITextForItem
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject _box;
    [SerializeField]
    private Slot _slot;
    [SerializeField]
    private GameObject SlotCross;
    [SerializeField]
    private GameObject _textPickUp;
    [SerializeField]
    private GameObject _textReplace;
    public static bool CrossPickUp = false;

    // Update is called once per frame
    void Update()
    {
        MoveToBox();
    } 

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
        if (Input.GetKey(KeyCode.E) && Slot._checkSlot)
        {

            CrossPickUp = true;
            _slot.PickUpItem();
            gameObject.SetActive(false);
            Debug.Log("pic");

        }
    }

    private void ReplaceItemPotion()
    {
        if (Input.GetKeyDown(KeyCode.E) && !Slot._checkSlot)
        {

            _slot.ReplaceItem();
            SlotCross.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

    }

    private void MoveToBox()
    {
        if(_box.activeSelf)
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, _box.transform.position, 1);
    }

    public void ShowText()
    {
        if (Slot._checkSlot)
        {
            _textReplace.gameObject.SetActive(false);
            _textPickUp.gameObject.SetActive(true);
        }
        else if (!Slot._checkSlot)
        {
            _textPickUp.gameObject.SetActive(false);
            _textReplace.gameObject.SetActive(true);
        }
    }

    public void HideText()
    {
        _textPickUp.gameObject.SetActive(false);
        _textReplace.gameObject.SetActive(false);
    }
}
