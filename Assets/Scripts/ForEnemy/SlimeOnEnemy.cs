using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeOnEnemy : MonoBehaviour
{
    [SerializeField] private ControllerEnemy _enemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Slime"))
           _enemy.Speed = 1;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Slime"))
            _enemy.Speed = 1;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Slime"))
            _enemy.Speed = 2f;
    }
}
