using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BarLoading : MonoBehaviour
{
    public static float _timer = 5f;
    SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.enabled = false;
    }

    private void Update()
    {
        Loading();
        Timer();
        ResetLoadingBar();
        DestroyObj();
    }

    private void Loading()
    {
        if(_spriteRenderer.enabled == true)
        gameObject.transform.localScale = new Vector3(_timer, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
    }

    private void Timer()
    {
        if (_timer != 0)
            _timer -= Time.deltaTime;
    }

    private void ResetLoadingBar()
    {
        if (_spriteRenderer.enabled == false)
        {
            _timer = 5;
            gameObject.transform.localScale = new Vector3(7, 1, 1);
        }
    }   

    private void DestroyObj()
    {
        if (_timer < 0)
        Destroy(gameObject);
    }
    
}
