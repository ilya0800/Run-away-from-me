using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPlayer : MonoBehaviour
{
    [SerializeField]
    GameObject _panelDeadth;

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("HitEnemy"))
        {
            _panelDeadth.SetActive(true);
            
        }
    }
}
