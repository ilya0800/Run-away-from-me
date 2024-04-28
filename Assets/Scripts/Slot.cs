using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Slot : MonoBehaviour
{
    
    [Header("Slot")]
   
    [SerializeField]
    GameObject _slot;

    public List<GameObject> _itemImage;
    public List<GameObject> _item;


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
    }

    public void PickUpItem()
    {
        if (_checkSlot)
        {        
            if (Potion.PickUpVisibility)
            {
               PotionVisibilityImage.SetActive(true);
               _checkSlot = false;
                Potion.PickUpVisibility = false;
            }

            if (PotionSpeed.PickUpSpeed)
            {
                PotionSpeedImage.SetActive(true);
                _checkSlot = false;
                PotionSpeed.PickUpSpeed = false;

            }

            if (Cross.CrossPickUp)
            {
                CrossImage.gameObject.SetActive(true);
                _checkSlot = false;
                Cross.CrossPickUp = false;
            }
        }
    }

    public void ReplaceItem()
    {
        if (!_checkSlot)
        {
            if (PotionSpeedImage != null)
            {
                if (!PotionSpeed.PickUpSpeed && PotionSpeedImage.activeSelf)
                {
                    PotionSpeedImage.SetActive(false);
                    PotionSpeedItem.gameObject.transform.position = new Vector3(_PosPlaeyer.position.x, _PosPlaeyer.position.y, _PosPlaeyer.position.z + 1);
                    PotionSpeedItem.SetActive(true);
                    Debug.Log("per");
                }
            }

            if (PotionVisibilityImage != null)
            {
                if (!Potion.PickUpVisibility && PotionVisibilityImage.activeSelf)
                {

                    PotionVisibilityImage.SetActive(false);
                    PotionVisibilityItem.gameObject.transform.position = new Vector3(_PosPlaeyer.position.x, _PosPlaeyer.position.y, _PosPlaeyer.position.z + 1);
                    PotionVisibilityItem.SetActive(true);
                    Debug.Log("per2");
                }
            }

            if (CrossImage != null)
            {
                if (!Cross.CrossPickUp && CrossImage.activeSelf)
                {
                    CrossImage.SetActive(false);
                    CrossItem.gameObject.transform.position = new Vector3(_PosPlaeyer.position.x, _PosPlaeyer.position.y, _PosPlaeyer.position.z + 1);
                    CrossItem.SetActive(true);
                    Debug.Log("per3");
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

