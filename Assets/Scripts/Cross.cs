using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Cross : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject _box;
    [SerializeField]
    Slot _slot;
    [SerializeField]
    GameObject SlotCross;
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
            PotionPickUp();
            ReplaceItemPotion();
        }
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

    
}
