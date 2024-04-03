using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
    private float _speed = 2;
    private Rigidbody2D _rigidbody2D;
    private float _posX;
    private float _posY;
    private bool _trap = false;
    private bool _isSlime = false;
    private bool _onMove = false;
    Animator animator;
    public delegate void Action(ref bool OnMove);
    public  Action ActionPlayer;
    public float PosX
    {
       set { _posX = value; }
       get { return _posX; }
    }

    public float PosY
    {
        set { _posY = value; }
        get { return _posY; }
    }

    public float Speed
    {
       set { _speed = value; }
       get { return _speed; }
    }

    public bool Trap
    {
        set { _trap = value; }
        get { return _trap; }
    }
    
    public bool IsSlime
    {
        set { _isSlime = value; }
        get { return _isSlime; }
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        ActionPlayer += MovePlayer;
        
    }
  
   private void Update()
   {
        PlayerFlip();
        ActionPlayer.Invoke(ref _onMove);
   }

    public void MovePlayer(ref bool OnMove)
    {
        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") > 0  || Input.GetAxis("Vertical") < 0)
        {
            _posX = Input.GetAxis("Horizontal") * _speed;
            _posY = Input.GetAxis("Vertical") * _speed;
            _rigidbody2D.velocity = new Vector3(_posX, _posY, 0);
            animator.SetBool("Active", true);
            OnMove = true;
        }
        else
        {
            animator.SetBool("Active", false);
            OnMove = false;
        }
 
    }

    private void PlayerFlip()
    {
        if(Input.GetAxis("Horizontal") > 0)
            gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        else if(Input.GetAxis("Horizontal") < 0)
            gameObject.transform.rotation = new Quaternion(0,180,0, 0);
    }   
}
