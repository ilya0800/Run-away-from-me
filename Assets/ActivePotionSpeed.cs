using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActivePotionSpeed : MonoBehaviour
{
    [SerializeField]
    Slot _slot;


    // Start is called before the first frame update
    static public bool ActiveSpeed = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ActivePotionSpeedKey());
        DeleteObj();
    }

    public static bool ActivePotionSpeedKey()
    {
        if (Input.GetKeyDown(KeyCode.H))
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
          //  gameObject.SetActive(false);
            //_slot._itemImage.Remove(gameObject);
            Destroy(gameObject);
        }
    }
} 