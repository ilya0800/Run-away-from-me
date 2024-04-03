using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Slot : MonoBehaviour
{
    
    [Header("Slot")]
   
    [SerializeField]
    GameObject _slot;

    public List<GameObject> _itemImage;

    
    [SerializeField] 
    List<GameObject> _item;

    [SerializeField]
    GameObject _textOccupiedItem;
    
    [SerializeField]
    GameObject _textFreeSlot;

    [SerializeField]
    Transform _PosPlaeyer;

    [SerializeField]
    GameObject CrossItem, PotionSpeedItem, PotionVisibilityItem;

    [SerializeField]
    GameObject CrossImage, PotionSpeedImage, PotionVisibilityImage; 

    private int _itemCount;
    public static bool _checkSlot = true;

    void Start()
    {
    }

    private void Update()
    {
        ItemCheck();
        PickUpItem();
        Debug.Log(_checkSlot);
       
    }

    public void PickUpItem()
    {
       
            if (PotionSpeed.PickUpSpeed && _checkSlot)
            {
                _itemImage[1].SetActive(true);
                PotionSpeed.PickUpSpeed = false;
                Debug.Log("PotionSpeed");
                _checkSlot = false;

            }
            if (Potion.PickUpVisibility && _checkSlot)
            {
                _itemImage[0].SetActive(true);
                Potion.PickUpVisibility = false;
                Debug.Log("PotionVisibility");
                _checkSlot = false;
            }
            if (Cross.CrossPickUp && _checkSlot)
            {
                _itemImage[2].SetActive(true);
                Cross.CrossPickUp = false;
                Debug.Log("Cross");
                _checkSlot = false;
            }

            //   for(int  i = 0; i < _itemCount;)
        
    }

    public void ReplaceItem()
    {
        if (!_checkSlot)
        {
            if (!PotionSpeed.PickUpSpeed)
            {
                _itemImage[1].SetActive(false);
                _item[1].SetActive(true);
            }
            if (!Potion.PickUpVisibility)
            {
                _itemImage[0].SetActive(false);
                _item[0].SetActive(true);

            }
            if (!Cross.CrossPickUp)
            {
                _itemImage[2].SetActive(false);
                _item[2].SetActive(true);     
            }

            for (int i = 0; i < _itemImage.Count; i++)
            {

            }
        }
    }

    private void ItemCheck()
    {
        //if (CrossActive.crossActive)
        //    _item.Remove(CrossItem);
        //if (ActivePotionSpeed.ActiveSpeed)
        //    _item.Remove(PotionSpeedItem);
        //if(ActivePotionVisibility.ActiveVisibility)
        //    _item.Remove(PotionVisibilityItem);
    }

}
