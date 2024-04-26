using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerEnemyMoveToCoffin : MonoBehaviour
{
    private float _timePermissionMove = 5;
    public static bool StartStop = true;
    private bool _startTime = false;
    // Start is called before the first frame update
    private void Start()
    {
        StopEnemy();
    }

    // Update is called once per frame
    private void Update()
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
        if(Input.anyKey)
            _startTime = true;
        if(_startTime)
        _timePermissionMove -= Time.deltaTime;
    }

}
