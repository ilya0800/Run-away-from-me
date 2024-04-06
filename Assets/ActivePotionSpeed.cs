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

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ActivePotionSpeedKey());
        DeleteObj();
    }

    public bool ActivePotionSpeedKey()
    {
        if (Input.GetKeyDown(KeyCode.H) && gameObject.activeSelf)
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
