using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    GameObject _childAttack;
    private AudioSource _attackSound;
    

    private void Start()
    {
        _attackSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        Attack();
    }  

    private void Attack()
    {
        if (gameObject.GetComponent<ControllerEnemy>().DistanceBetweenEnemyAndPlayer() < 2f)
        {
            gameObject.GetComponent<Animator>().SetBool("Attack", true);
            if (_childAttack.activeSelf == true)
            {
                if (!_attackSound.isPlaying)
                    _attackSound.Play();
                Debug.Log("attack");
            }
        }
        else if (gameObject.GetComponent<ControllerEnemy>().DistanceBetweenEnemyAndPlayer() > 2.3)
            gameObject.GetComponent<Animator>().SetBool("Attack", false);
    }
}

