using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    [SerializeField]
    ActivePotionVisibility _potionVis;
    [SerializeField]
    GameObject _darkness;
    [SerializeField]
    private OverLapDarkness _overlapDarkness;

    private bool _oneUse = true;
    private void Update()
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
        _oneUse = false;
        _darkness.SetActive(false);
        yield return new WaitForSeconds(3);
        _darkness.SetActive(true);
        _overlapDarkness.enabled =false;
         yield return new WaitForSeconds(5);
        _overlapDarkness.enabled = true;
    }
}
