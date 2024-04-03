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
    private float _time = 0f;
    private int _count = 7;

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
        _time += Time.deltaTime;
        StartCoroutine(CountOnEight());
    }
    
    IEnumerator CountOnEight()
    {
        image[_count].GetComponent<Image>().enabled = true;
        yield return new WaitForSeconds(1);
        image[_count].GetComponent<Image>().enabled = false;
        _count--;
        _time = 0;
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
