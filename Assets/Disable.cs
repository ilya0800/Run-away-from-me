using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    [SerializeField]
    ActivePotionVisibility _potionVis;
    [SerializeField]
    GameObject _darkness;
    private bool _oneUse = true;

    void Update()
    {
        ActivePotion();
    }

    private void ActivePotion()
    {
        if (_potionVis.ActivePotion() && _oneUse)
            StartCoroutine(PotionSearchActive());
    }

    IEnumerator PotionSearchActive()
    {
        Debug.Log("gg");
        _darkness.SetActive(false);
        yield return new WaitForSeconds(2);
        _darkness.SetActive(true);
        _oneUse = false;
        StopAllCoroutines();
    }
}
