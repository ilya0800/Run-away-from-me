using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerEnemyMoveToCoffin : MonoBehaviour
{
    private float _timePermissionMove = 8;
    public static bool StartStop = true;
    // Start is called before the first frame update
    void Start()
    {
        StopEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        StopEnemy();
        MinusTime();
    }

    private void StopEnemy() 
    {
        gameObject.GetComponent<Collider2D>().isTrigger = true;
        StartStop = true;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        if (_timePermissionMove <= 0)
        {
            StartStop = false;
            gameObject.GetComponent<Collider2D>().isTrigger = false;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

        }

    }

    private void MinusTime()
    {
        _timePermissionMove -= Time.deltaTime;
    }

}