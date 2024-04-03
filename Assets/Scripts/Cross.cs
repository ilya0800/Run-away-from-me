using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Cross : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Transform _boxPosition;
    [SerializeField]
    Slot _slot;
    [SerializeField]
    GameObject _textPickUpItem;
    [SerializeField]
    GameObject _textReplace;
    [SerializeField]
    GameObject SlotCross;
    public static bool CrossPickUp;
 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
//        MoveToBox();
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
        if (Input.GetKey(KeyCode.E) && Slot._checkSlot)
        {

            CrossPickUp = true;
            //_slot.PickUpItem();
            gameObject.SetActive(false);

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

    private void OnTriggerExit2D(Collider2D collision)
    {
        _textPickUpItem.SetActive(false);
        _textReplace.SetActive(false);
    }

    private void MoveToBox()
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, _boxPosition.transform.position, 1);
    }
}
