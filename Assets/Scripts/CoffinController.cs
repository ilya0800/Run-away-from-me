using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffinController : MonoBehaviour
{
   static public Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    static public void OpenCoffin()
    {
        _animator.SetBool("Open", true);
    }

   static public void CloseCoffin()
    {
        _animator.SetBool("Open", false);
    }
}
