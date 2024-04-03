using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePotionVisibility : MonoBehaviour
{
    [SerializeField]
    Slot _slot;


    // Start is called before the first frame update
    static public bool ActiveVisibility = false;
    void Start()
    {
        
    }

    // Update is called once per frame
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
          // gameObject.SetActive(false);

            //_slot._itemImage.Remove(gameObject);
            Destroy(gameObject);
        }
    }

}
