using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CrossActive : MonoBehaviour
{
    public static bool crossActive = false;
    [SerializeField]
    Slot _slot;
    [SerializeField]
    GameObject _cross;

    private void Update()
    {
        DeleteObj();
    }

    public bool ActiveCross()
    {
        if (Input.GetKey(KeyCode.F) && gameObject.activeSelf)
        {
            crossActive = true;
            return crossActive;
        }
        return crossActive;
    }

 

    private void DeleteObj()
    {
        if (crossActive)
        {
            Slot._checkSlot = true;
            _slot._item.Remove(_cross);
            Destroy(gameObject);
        }
    }
}
