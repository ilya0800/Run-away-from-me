using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject _panelDeadth;

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (!ImmortalityAtStart())
        {
            if (collider2D.gameObject.CompareTag("HitEnemy"))
                _panelDeadth.SetActive(true);
            if (collider2D.gameObject.CompareTag("Trap"))
                _panelDeadth.SetActive(true);
            if (collider2D.gameObject.CompareTag("Fire"))
                _panelDeadth.SetActive(true);
        }
    }

    private bool ImmortalityAtStart()
    {
        float _timer = 0;
        _timer += Time.time;
       
        if( _timer > 1)
        return false;

        return true;
    }
}
