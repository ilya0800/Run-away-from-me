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
    PlayerRay _playerRay;
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
        _oneUse = false;
        Debug.Log("gg");
        _darkness.SetActive(false);
        yield return new WaitForSeconds(3);
        _darkness.SetActive(true);
        yield return new WaitForSeconds(3);
        _playerRay.distanceHitDown = 0.5f;
        _playerRay.distanceHitUp = 0.5f;
        _playerRay.distanceHitRight = 0.5f;
        Debug.Log("2log");
        yield return new WaitForSeconds(3);
        _playerRay.distanceHitRight = 1.5f;
        _playerRay.distanceHitUp = 1.5f;
        _playerRay.distanceHitDown = 1.3f;
        Debug.Log("3log");
        StopAllCoroutines();
    }
}
