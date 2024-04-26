using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class TimerWave : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Image[] image;
    [SerializeField] CoffinController controller;
    private int _count = 5;
    private bool _startCoroutine = false;

    void Start()
    {
        Disable();
    }

    // Update is called once per frame
    void Update()
    {
        MinusTimer();
    }

    private void MinusTimer()
    {
        if (Input.anyKeyDown)
            _startCoroutine = true;
        if(_startCoroutine)
        StartCoroutine(CountOnFight());
    }
    
    IEnumerator CountOnFight()
    {
        image[_count].GetComponent<Image>().enabled = true;
        yield return new WaitForSeconds(1);
        image[_count].GetComponent<Image>().enabled = false;
        _count--;
        if (_count == 0)
        {
            CoffinController.OpenCoffin();
        }
        StopAllCoroutines();      
    }

    private void Disable()
    {
        for(int i = 0; i < image.Length; i++)
        {
            image[i].GetComponentInChildren<Image>().enabled=false;
        }
    }
}
