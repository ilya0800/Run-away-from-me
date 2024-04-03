using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public List<GameObject> _item;

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

    public static bool _checkSlot = true;

    private void Update()
    {
        ItemCheck();
        PickUpItem();
        Debug.Log(_checkSlot);
       
    }

    public void PickUpItem()
    {
        if (_checkSlot)
        {
            
                if (Potion.PickUpVisibility)
                {
                    PotionVisibilityImage.SetActive(true);
                    Potion.PickUpVisibility = false;
                    _checkSlot = false;
                }

                if (PotionSpeed.PickUpSpeed)
                {
                    PotionSpeedImage.SetActive(true);
                    PotionSpeed.PickUpSpeed = false;
                    _checkSlot = false;
                }

                if (Cross.CrossPickUp)
                {
                    CrossImage.gameObject.SetActive(true);
                    //_itemImage[i].SetActive(true);
                    Cross.CrossPickUp = false;
                    _checkSlot = false;
                }
            
        }
    }

    public void ReplaceItem()
    {
        if (!_checkSlot)
        {
            for (int i = 0; i < _itemImage.Count; i++)
            {
                if (!PotionSpeed.PickUpSpeed)
                {
                    _itemImage[i].SetActive(false);
                    _item[i].SetActive(true);
                }

                if (!Potion.PickUpVisibility)
                {
                    _itemImage[i].SetActive(false);
                    _item[i].SetActive(true);

                }
                if (!Cross.CrossPickUp)
                {
                    _itemImage[i].SetActive(false);
                    _item[i].SetActive(true);
                }
            }
        }
    }       
   
    private void ItemCheck()
    {
        for (int i = 0; i < _itemImage.Count; i++)
        {
            if (_itemImage[i] == null)
                _itemImage.RemoveAt(i);
        }
    }
}

