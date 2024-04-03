using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePotionVisibility : MonoBehaviour
{
    [SerializeField]
    Slot _slot;
    [SerializeField]
    GameObject _potionVisibility;

    static public bool ActiveVisibility = false;

    void Update()
    {
        DeleteObj();
        Debug.Log(ActivePotion());
    }

    public static bool ActivePotion()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ActiveVisibility = true;
            return ActiveVisibility;
        }
        return ActiveVisibility;
    }

    private void DeleteObj()
    {
        if (ActiveVisibility)
        {
            Slot._checkSlot = true;
            _slot._item.Remove(_potionVisibility);
            Destroy(gameObject);
        }
    }

}
