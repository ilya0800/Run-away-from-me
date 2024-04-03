using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CrossActive : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool crossActive = false;

    [SerializeField]
    Slot _slot;

    private void Update()
    {
        DeleteObj();
    }

    public static bool ActiveCross()
    {
        if (Input.GetKeyDown(KeyCode.G))
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
            //_slot._itemImage.Remove(gameObject);
          //  gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
