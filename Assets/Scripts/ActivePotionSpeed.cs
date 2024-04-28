using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActivePotionSpeed : MonoBehaviour
{
    [SerializeField]
    Slot _slot;
    [SerializeField]
    GameObject _potionSpeed;
    static public bool ActiveSpeed = false;

    void Update()
    {
        DeleteObj();
    }

    public bool ActivePotionSpeedKey()
    {
        if (Input.GetKey(KeyCode.F) && gameObject.activeSelf)
        {
            ActiveSpeed = true;
            return ActiveSpeed;
        }
        return ActiveSpeed;
    }

    private void DeleteObj()
    {
        if (ActiveSpeed)
        {
            Slot._checkSlot = true;
            _slot._item.Remove(_potionSpeed);
            Destroy(gameObject);
        }
    }
} 
